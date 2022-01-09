
function displayLocation(position) {
	var latitude = position.coords.latitude;
	var longitude = position.coords.longitude;

	var pTime = document.getElementById("time");
	t2 = Date.now();
	pTime.innerHTML += "<br>Computed in " + (t2-t1) + " milliseconds";

	var pLocation = document.getElementById("location");
	pLocation.innerHTML += latitude + ", " + longitude + "<br>";
  
	var pInfo = document.getElementById("info");
	var date = new Date(position.timestamp);
	pInfo.innerHTML = "Location timestamp: " + date + "<br>";
	pInfo.innerHTML += "Accuracy of location: " + 
						position.coords.accuracy +
						" meters<br>";
	if (position.coords.altitude) {
		pInfo.innerHTML += "Altitude: " + position.coords.altitude;
	}

	if (position.coords.altitudeAccuracy) {
		pInfo.innerHTML += " with accuracy " + 
			position.coords.altitudeAccuracy + "???";
	}
	pInfo.innerHTML += "<br>";

	if (position.coords.heading) {
		pInfo.innerHTML += "Heading: " + position.coords.heading + "<br>";
	}

	if (position.coords.speed) {
		pInfo.innerHTML += "Speed: " + position.coords.speed + "<br>";
	}
}

function displayError(error) {
	var errors = ["Unknown error", "Permission denied by user", "Position not available", "Timeout error"];
	var message = errors[error.code];
	console.warn("Error in getting your location: " + message, error.message);
	var pError = document.getElementById("error");
	pError.innerHTML = "Error in getting your location: " + message + ", " + error.message;
}

var t1 = 0, t2 = 0;

window.onload = function() {
	if (navigator.geolocation) {
		var pTime = document.getElementById("time");
		pTime.innerHTML = "Timeout: 5000, maximumAge: 0";

		t1 = Date.now();

		navigator.geolocation.getCurrentPosition(displayLocation, 
			displayError,
			{ enableHighAccuracy: true, timeout: 5000, maximumAge: 0 }
		);
	} else {
		alert("Sorry, this browser doesn't support geolocation!");
	}
}

