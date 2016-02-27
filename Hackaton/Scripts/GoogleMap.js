﻿function initialize() {
    var styles = [{ "featureType": "administrative", "elementType": "labels.text", "stylers": [{ "weight": "0.01" }, { "visibility": "on" }] }, { "featureType": "administrative", "elementType": "labels.text.fill", "stylers": [{ "color": "#b0b0b0" }, { "visibility": "off" }, { "weight": "0.01" }] }, { "featureType": "administrative", "elementType": "labels.text.stroke", "stylers": [{ "weight": "0.01" }, { "visibility": "on" }, { "color": "#444444" }, { "lightness": "26" }] }, { "featureType": "administrative.country", "elementType": "all", "stylers": [{ "visibility": "off" }] }, { "featureType": "administrative.neighborhood", "elementType": "all", "stylers": [{ "visibility": "off" }] }, { "featureType": "administrative.land_parcel", "elementType": "all", "stylers": [{ "visibility": "off" }, { "color": "#ff0000" }] }, { "featureType": "landscape", "elementType": "all", "stylers": [{ "color": "#ffffff" }] }, { "featureType": "landscape", "elementType": "geometry.fill", "stylers": [{ "visibility": "on" }, { "color": "#ffffff" }] }, { "featureType": "landscape", "elementType": "labels.text", "stylers": [{ "weight": "0.01" }, { "visibility": "on" }] }, { "featureType": "landscape.natural", "elementType": "geometry.fill", "stylers": [{ "color": "#ffffff" }, { "visibility": "off" }] }, { "featureType": "landscape.natural", "elementType": "labels.text", "stylers": [{ "weight": "0.01" }, { "visibility": "on" }] }, { "featureType": "poi", "elementType": "all", "stylers": [{ "visibility": "off" }] }, { "featureType": "poi", "elementType": "labels.text", "stylers": [{ "weight": "0.01" }, { "visibility": "on" }] }, { "featureType": "poi.park", "elementType": "geometry.fill", "stylers": [{ "visibility": "on" }, { "color": "#9cd371" }, { "lightness": "55" }, { "saturation": "-13" }] }, { "featureType": "poi.park", "elementType": "labels.text", "stylers": [{ "weight": "0.01" }, { "visibility": "on" }] }, { "featureType": "road", "elementType": "geometry.fill", "stylers": [{ "visibility": "on" }, { "color": "#f0f0f0" }] }, { "featureType": "road", "elementType": "geometry.stroke", "stylers": [{ "visibility": "off" }] }, { "featureType": "road", "elementType": "labels.text", "stylers": [{ "visibility": "on" }, { "weight": "0.01" }, { "color": "#848484" }] }, { "featureType": "road", "elementType": "labels.icon", "stylers": [{ "visibility": "off" }] }, { "featureType": "transit", "elementType": "geometry.fill", "stylers": [{ "visibility": "on" }, { "color": "#d1d1d1" }] }, { "featureType": "transit", "elementType": "geometry.stroke", "stylers": [{ "visibility": "off" }] }, { "featureType": "transit", "elementType": "labels.icon", "stylers": [{ "visibility": "off" }] }, { "featureType": "water", "elementType": "all", "stylers": [{ "color": "#cbdee9" }, { "visibility": "on" }] }];
    var styledMap = new google.maps.StyledMapType(styles, { name: "Styled Map" });

    var mapProp = {
        center: new google.maps.LatLng(52.231236, 21.007281),
        zoom: 12,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    var map = new google.maps.Map(document.getElementById("googleMap"), mapProp);

    map.mapTypes.set('map_style', styledMap);
    map.setMapTypeId('map_style');

    displayTrees(map);

}
google.maps.event.addDomListener(window, 'load', initialize);

function displayTrees(map) {
    return $.ajax({
        url: 'Map/GetTrees',
        type: 'GET',
        dataType: 'json',
        cache: false,
        success: function (results) {
            for (var i = 0; i < results.length; i++) {
                var marker = new google.maps.Marker({
                   // position: { lat: 52.231236, lng: 21.007281 },
                    position: { lat: results[i].CoordY, lng: results[i].CoordX },
                    icon: '../Images/tree_green.png'
                });
                marker.setMap(map);
            }
        },
        error: function () {
            alert('Error occured');
        }
    });
}
