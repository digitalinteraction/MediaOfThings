var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : new P(function (resolve) { resolve(result.value); }).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments)).next());
    });
};
class ClientProxy {
    constructor(endpoint) {
        this.endpoint = endpoint;
    }
    getTimerange(start, end) {
        return __awaiter(this, void 0, void 0, function* () {
            if (start >= this.startCache && end <= this.endCache) {
                return this.cache;
            }
            let startCache = new Date(start.getTime() - this.cachePeriod);
            let endCache = new Date(end.getTime() + this.cachePeriod);
            let requestUrl = URL.createObjectURL(`${this.endpoint}?start=${startCache.toISOString()}&end=${endCache.toISOString()}`);
            yield new Promise(function (resolve, reject) {
                let xhr = new XMLHttpRequest();
                xhr.open("GET", requestUrl);
                xhr.onload = function () {
                    if (xhr.status >= 200 && xhr.status < 300) {
                        resolve(xhr.response);
                        return;
                    }
                    reject({ status: xhr.status, statusText: xhr.statusText });
                };
                xhr.onerror = function () {
                    reject({ status: xhr.status, statusText: xhr.statusText });
                };
                xhr.send();
            });
        });
    }
}
//# sourceMappingURL=ClientProxy.js.map