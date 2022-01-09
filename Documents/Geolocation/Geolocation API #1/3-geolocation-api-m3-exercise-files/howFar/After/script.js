var trackId;
var locations = [];

function displayLocation(position) {
	var latitude = position.coords.latitude;
	var longitude = position.coords.longitude;

	var googleLoc = new google.maps.LatLng(
		position.coords.latitude, 
		position.coords.longitude);
	locations.push(googleLoc);
  
	var pLocation = document.getElementById("location");
	pLocation.innerHTML += latitude + ", " + longitude + "<br>";
  
}

function displayError(error) {
	var errors = ["Unknown error", "Permission denied by user", "Position not available", "Timeout error"];
	var message = errors[error.code];
	console.warn("Error in getting your location: " + message, error.message);
}

function trackMe() {
	trackId = navigator.geolocation.watchPosition(displayLocation, displayError);
}

function clearTracking() {
	if (trackId) {
		navigator.geolocation.clearWatch(trackId);
		trackId = null;
	}
}

function computeTotalDistance() {
	var totalDistance = 0;

	if (locations.length > 1) {
		for (var i = 1; i < locations.length; i++) {
			totalDistance += google.maps.geometry.spherical.computeDistanceBetween(locations[i-1], locations[i]);
		}
	}
	return totalDistance;
}

window.onload = function() {
	var pDistance = document.getElementById("distance");
	var trackButton = document.querySelector("button");
	trackButton.onclick = function(e) {
		e.preventDefault();
		if (trackButton.innerHTML === "Start") {
			trackButton.innerHTML = "Stop";
			trackMe();
		} else {
			trackButton.innerHTML = "Start";
			clearTracking();
			var d = computeTotalDistance();
			if (d > 0) {
				d = Math.round(d * 1000) / 1000;
				var miles = d/1.6;
				pDistance.innerHTML = "Total distance traveled: " + d + "km";
				pDistance.innerHTML += "<br>Total distance traveled: " + miles + "m";
			} else {
				pDistance.innerHTML = "You didn't travel anywhere at all.";
			}
		}
	};
};


