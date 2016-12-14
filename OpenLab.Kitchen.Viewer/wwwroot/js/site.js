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
                        var reference = new Date(document.getElementById('referencetime').value);
                        var start = new Date(reference
                            .setSeconds(reference.getSeconds() + (timingObject.clock.now() - 5)));
                        var end = new Date(reference
                            .setSeconds(reference.getSeconds() + (timingObject.clock.now() + 5)));
                        updateWax3(start, end);
                        updateRfid(start, end);
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

    function updateWax3(start, end) {
        var xhr = new XMLHttpRequest();
        xhr.open('get', 'http://localhost:2040/api/wax3/timerange?start=' + start.toISOString() + '&end=' + end.toISOString(), true);
        xhr.onerror = function (e) {
            console.log(e);
        };
        xhr.onload = function() {
            var data = JSON.parse(xhr.responseText);

            for (var textArea in document.getElementsByClassName('wax3')) {
                textArea.value = '';
            }

            data.map(function(wax3Data) {
                var waxId = document.getElementById('wax3-' + wax3Data.deviceId);
                if (waxId === undefined) {
                    waxId = document.getElementById('wax3-unknown');
                }
                waxId.value = 'deviceId: ' + wax3Data.deviceId + 'x:' + wax3Data.accX + ',\ny:' + wax3Data.accY + ',\nz:' + wax3Data.accZ;
            })
        }.bind(this);
        xhr.send();
    }

    function updateRfid(start, end) {
        var xhr = new XMLHttpRequest();
        xhr.open('get', 'http://localhost:2040/api/rfidstate/timerange?start=' + start.toISOString() + '&end=' + end.toISOString(), true);
        xhr.onerror = function (e) {
            console.log(e);
        };
        xhr.onload = function () {
            var data = JSON.parse(xhr.responseText);

            for (var rfid in document.getElementsByClassName('rfid')) {
                rfid.className = 'rfid';
                rfid.innerText = '';
            }

            data.map(function(rfidData) {
                rfidData.transponders.map(function(trans) {
                    if (trans.active) {
                        var transId = document.getElementById('rfid-' + trans.Id);
                        if (transId === undefined) {
                            transId = document.getElementById('rfid-unknown');
                            transId.innerText += 'transId: ' + trans.ID + ', padId: ' + rfidData.deviceId;
                        } else {
                            transId.className = 'rfid rfid-on';
                            transId.innerText += rfidData.deviceId;
                        }
                    }
                });
            });
        }.bind(this);
        xhr.send();
    }
});