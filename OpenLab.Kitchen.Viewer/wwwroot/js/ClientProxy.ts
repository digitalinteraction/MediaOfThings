class ClientProxy {
    endpoint:URL;
    cache: JSON[];
    startCache: Date;
    endCache: Date;

    cachePeriod: number = 30000;

    constructor(endpoint: URL) {
        this.endpoint = endpoint;
    }

    async getTimerange(start: Date, end: Date): Promise<JSON[]> {
        if (start >= this.startCache && end <= this.endCache) {
            return this.cache.filter(d => {
                var timestamp = new Date(d["timestamp"]);
                return start <= timestamp && end > timestamp;
            });
        }

        let startCache = new Date(start.getTime() - this.cachePeriod);
        let endCache = new Date(end.getTime() + this.cachePeriod);
        let requestUrl = URL.createObjectURL(`${this.endpoint}?start=${startCache.toISOString()}&end=${endCache.toISOString()}`);

        var request = new Promise<JSON[]>((resolve, reject) => {
            let xhr = new XMLHttpRequest();
            xhr.open("GET", requestUrl);
            xhr.onload = () => {
                if (xhr.status >= 200 && xhr.status < 300) {
                    resolve(JSON.parse(xhr.response));
                } else {
                    reject({ status: xhr.status, statusText: xhr.statusText });
                }
            };
            xhr.onerror = () => {
                reject({ status: xhr.status, statusText: xhr.statusText });
            };
            xhr.send();
        });

        this.cache = await request;

        return this.cache.filter(d => {
            var timestamp = new Date(d["timestamp"]);
            return start <= timestamp && end > timestamp;
        });
    }
}