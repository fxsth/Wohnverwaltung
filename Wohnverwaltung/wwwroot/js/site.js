var csvData;

function load_csv() {
    var settings = {
        download: true,
        delimiter: ",",
        header: true,
        skipEmptyLines: true,
        complete: function (data) {
            csvData = data.data;
        }
    };
    Papa.parse('/data/zuordnung_plz_ort.csv', settings);
}

function check_plz(plz) {
    var pattern_plz = new RegExp("^" + plz + ".*$");
    var ort;
    $.each(csvData, function (index, value) {
        if (value.plz.match(pattern_plz)) {
            $('#search-result').attr('value', value.ort);
            ort = value.ort;
            return false;
        }
    });
    return ort;
}