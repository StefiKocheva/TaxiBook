'use strict';

function loadGoogleMaps() {
  // Set your Google Maps key here
  let key = "YOUR_KEY_HERE";
  // Set your callback function here
  let callback = "gmapController.initialize";

  // Create a new <script> element
  let elem = document.createElement("script");
  elem.type = "text/javascript";
  elem.src = "https://maps.googleapis.com/maps/api/js?key=" + key + "&callback=" + callback;
  document.body.appendChild(elem);
}