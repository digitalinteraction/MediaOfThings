$(function () {
    // Configure Players
    var videos = document.getElementsByTagName('video');
    var seekHead = document.getElementById('seekhead');
    var playBtn = document.getElementById('play');
    var pauseBtn = document.getElementById('pause');

    var timingObject;
    var isSeeking = false;

    for (var i = 0; i < videos.length; i++) {
        videos[i].addEventListener('loadstart', function (event) {
            event.target._dashjs_player.setMaxAllowedBitrateFor('video', 4600);
        });

        videos[i].addEventListener('loadedmetadata',
            function (event) {
                if (timingObject === undefined) {
                    timingObject = new TIMINGSRC.TimingObject({ range: [0, event.target.duration] });
                    seekHead.min = 0;
                    seekHead.step = 0.25;
                    seekHead.max = event.target.duration;
                    timingObject.on('timeupdate', function () {
                        if (!isSeeking) {
                            seekHead.value = timingObject.clock.now();
                        }
                    });
                }

                var sync = new TIMINGSRC.MediaSync(event.target, timingObject);
            });
    }

    playBtn.addEventListener('click', function (event) {
        timingObject.update({ velocity: 1.0 });
    });

    pauseBtn.addEventListener('click', function (event) {
        timingObject.update({ velocity: 0.0 });
    });

    seekHead.addEventListener('mousedown', function (event) {
        isSeeking = true;
    });

    seekHead.addEventListener('mouseup', function (event) {
        timingObject.update({ position: event.target.value });
        isSeeking = false;
    });

    // Configure charts
    var wax3Canvas = document.getElementsByClassName('wax3');
    var wax3Charts = {};

    for (var i = 0; i < wax3Canvas.length; i++) {
        wax3Charts[wax3Canvas[i].id.slice(5)] = new Chart(wax3Canvas[i],
        {
            type: 'line',
            data: {
                labels: [],
                datasets: [
                {
                    label: 'X',
                    data: []
                }, {
                    label: 'Y',
                    data: []
                }, {
                    label: 'Z',
                    data: []
                }]
            },
            options: {
                scales: {
                    xAxes: [{
                        display: false
                    }]
                },
                legend: {
                    display: false
                }
            }
        })
    }

    window.updateWax3Data = function(start, end) {
        var xhr = new XMLHttpRequest();
        xhr.open('get', 'http://localhost:2040/api/wax3?starttime=' + start + '&endtime=' + end, true);
        xhr.onerror = function (e) {
            console.log(e);
        };
        xhr.onload = function() {
            var data = JSON.parse(xhr.responseText);
            var wax3 = {};
            data.map(function(wax3Data) {
                if (wax3[wax3Data.deviceId] === undefined) {
                    wax3[wax3Data.deviceId] = [[],[],[]];
                }

                wax3[wax3Data.deviceId][0].push(
                    {
                        x: new Date(wax3Data.timestamp).getTime(),
                        y: wax3Data.accX * 8 / 512.0
                    }
                );

                wax3[wax3Data.deviceId][1].push(
                    {
                        x: new Date(wax3Data.timestamp).getTime(),
                        y: wax3Data.accY * 8 / 512.0
                    }
                );

                wax3[wax3Data.deviceId][2].push(
                    {
                        x: new Date(wax3Data.timestamp).getTime(),
                        y: wax3Data.accZ * 8 / 512.0
                    }
                );
            });

            var labels = [];
            for (var i = (end / 1000) - 621355968000000000; i >= (start / 1000) - 621355968000000000; i--) {
                labels.push(i);
            }

            for (var id in wax3) {
                if (wax3.hasOwnProperty(id)) {
                    wax3Charts[id].data.datasets[0].data = wax3[id][0];
                    wax3Charts[id].data.datasets[1].data = wax3[id][1];
                    wax3Charts[id].data.datasets[2].data = wax3[id][2];

                    wax3Charts[id].data.labels = labels;

                    wax3Charts[id].update();
                }
            }
        }.bind(this);
        xhr.send();
    }
});