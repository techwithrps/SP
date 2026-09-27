function GetLocation(latitude, longitude) {
    var FNumber = latitude;
    var SNumber = longitude;
    var mapOptions =
                {
                    center: new google.maps.LatLng(FNumber, SNumber),
                    zoom: 14,
                    marker: true,
                    mapTypeId: google.maps.MapTypeId.ROADMAP

                };
    var infoWindow = new google.maps.InfoWindow();
    var latlngbounds = new google.maps.LatLngBounds();
    //var map = new google.maps.Map(document.getElementById("dvMap"), mapOptions);
    var map = new google.maps.Map(document.getElementById("<%=dvMap.ClientID%>"), mapOptions);
    var latlng = new google.maps.LatLng(FNumber, SNumber);
    var geocoder = new google.maps.Geocoder();
    geocoder.geocode({ 'latLng': latlng }, function (results, status) {
        if (status == google.maps.GeocoderStatus.OK) {
            if (results[1]) {
                document.getElementById('<%= hdnLocation.ClientID%>').value = results[1].formatted_address;
            }
        }
    });

    var image = "http://27.251.75.182/Kanpur/Images/truck.png";
    var marker = new google.maps.Marker({
        position: new google.maps.LatLng(FNumber, SNumber),
        map: map,
        icon: image
    });
    marker.setMap(map);



    google.maps.event.addListener(map, 'click', function (e) {
        var latlng = new google.maps.LatLng(e.latLng.lat(), e.latLng.lng());
        var geocoder = geocoder = new google.maps.Geocoder();
        geocoder.geocode({ 'latLng': latlng }, function (results, status) {
            if (status == google.maps.GeocoderStatus.OK) {
                if (results[1]) {
                    alert("Location: " + results[1].formatted_address + "\r\nLatitude: " + e.latLng.lat() + "\r\nLongitude: " + e.latLng.lng());
                    document.getElementById('<%= hdnLocation.ClientID%>').value = results[1].formatted_address;

                }
            }
        });
    });
}