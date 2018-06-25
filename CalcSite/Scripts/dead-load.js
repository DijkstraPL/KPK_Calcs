function sumLoad(maxOrMin) {
    var tds = document.getElementById('count-it').getElementsByTagName('td');
    var sum = 0;
    for (var i = 0; i < tds.length; i++) {
        if (tds[i].className == 'count-' + maxOrMin + '-load') {
            sum += isNaN(tds[i].innerHTML) ? 0 : parseFloat(tds[i].innerHTML);
        }
    }
    return sum;
    //document.getElementById('count-it').getElementById('min-load-sum').innerHTML = sum;
}

function checkUnit() {
    var tds = document.getElementById('count-it').getElementsByTagName('td');
    var unit;
    for (var i = 0; i < tds.length; i++) {
        if (tds[i].className == 'unit')
            unit[i] += tds[i].innerHTML;
    }
    
}

var allLoads = {
    minLoad: sumLoad('min'),
    maxLoad: sumLoad('max'),
}

