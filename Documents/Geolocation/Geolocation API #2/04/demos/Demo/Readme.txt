map-01 - Hard-coded google map sample
  Be sure to put google script tag at the end
map-02 - Embed a Google Map using dynamic script loading
map-03 - Adding a marker
  Added drawMarker(pos) method
map-04 - Adding an info window
  Added 'infoWindow' private variable
    Only use one, otherwise you will have multiple info windows open at the same time
  Added addInfoWindow() method
map-05 - Using a custom marker
  Added 'icon' property in drawMarker()
map-06 - Two markers, two info windows
  Added 'userMap' object
  Modified initialize() method to set boundary  
map-07 - Get user's position, add marker, reorient map between the two markers
  Added mapObjects[]
  Added drawMapObjects() method
  Added addCurrentLocation() method