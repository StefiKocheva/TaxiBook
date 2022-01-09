Modified loadGoogleMaps.js file
  Added &libraries=geometry to draw a rectangle

map-01 - Draw a geofence around delivery area
  Added drawFence() method
map-02 - Look up address and add marker to map
  Added address input field and button
  Added setMarkerOnAddress() method
map-03 - Is address within delivery address
  Added code in setMarkerOnAddress() method to see if marker is in delivery area boundaries
  if (!deliveryArea.getBounds().contains(addrMarker.position)) {
    displayError("Address is NOT in delivery area");
  }
