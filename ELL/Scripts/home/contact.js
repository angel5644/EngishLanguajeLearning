function initMap() {
    var ell = { lat: 19.259428, lng: -103.714692 };

    var map = new google.maps.Map(document.getElementById('map'), {
        zoom: 16,
        center: ell
    });

    var marker = new google.maps.Marker({
        position: ell,
        title: "English Language Learning",
        map: map
    });
}