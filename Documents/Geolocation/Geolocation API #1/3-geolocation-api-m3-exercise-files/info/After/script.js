
function displayLocation(position) {
	var latitude = position.coords.latitude;
	var longitude = position.coords.longitude;

	var pLocation = document.getElementById("location");
	pLocation.innerHTML += latitude + ", " + longitude + "<br>";
  
	var pInfo = document.getElementById("info");
	var date = new Date(position.timestamp);
	pInfo.innerHTML = "Location timestamp: " + date + "<br>";
	pInfo.innerHTML += "Accuracy of location: " + position.coords.accuracy + " meters<br>";

	if (position.coords.altitude) {
		pInfo.innerHTML += "Altitude: " + position.coords.altitude;
	} else {
		console.log("Altitude: ", position.coords.altitude);
	}

	if (position.coords.altitudeAccuracy) {
		pInfo.innerHTML += " with accuracy " + 
			position.coords.altitudeAccuracy + " in meters";
	} else {
		console.log("Altitude accuracy: ", position.coords.altitudeAccuracy);
	}
	pInfo.innerHTML += "<br>";

	if (position.coords.heading) {
		pInfo.innerHTML += "Heading: " + position.coords.heading + "<br>";
	} else {
		console.log("Heading is ", position.coords.heading);
	}

	if (position.coords.speed) {
		pInfo.innerHTML += "Speed: " + position.coords.speed + "<br>";
	} else {
		console.log("Speed is ", position.coords.speed);
	}
}

function displayError(error) {
	var errors = ["Unknown error", "Permission denied by user", "Position not available", "Timeout error"];
	var message = errors[error.code];
	console.warn("Error in getting your location: " + message, error.message);
}

window.onload = function() {
	if (navigator.geolocation) {
		navigator.geolocation.getCurrentPosition(displayLocation, displayError);
	} else {
		alert("Sorry, this browser doesn't support geolocation!");
	}
}

