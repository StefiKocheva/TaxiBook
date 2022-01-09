
function displayLocation(position) {
	var latitude = position.coords.latitude;
	var longitude = position.coords.longitude;

	var pLocation = document.getElementById("location");
	pLocation.innerHTML += latitude + ", " + longitude + "<br>";
}

window.onload = function() {
	if (navigator.geolocation) {
		navigator.geolocation.getCurrentPosition(displayLocation);
	} else {
		alert("Sorry, this browser doesn't support geolocation!");
	}
}


