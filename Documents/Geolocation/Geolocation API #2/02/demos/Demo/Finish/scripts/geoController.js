'use strict';

var geoController = (function () {
  // ************************************
  // Private Variables
  // ************************************
  let position = null;
  let lastMessage = null;
  let lastError = null;
  let successCallback = null;
  let errorCallback = null;
  let options = {
    enableHighAccuracy: true,  // Enable high accuracy, if available
    timeout: 10000,            // 10 seconds
    maximumAge: 300000         // Only accept cached positions whose age is not greater than 5 minutes
  };

  // ************************************
  // Private Functions
  // ************************************
  function getCurrentLocation(success, error) {
    // Set callbacks
    successCallback = success;
    errorCallback = error;

    // Reset private variables
    position = null;
    lastError = null;
    lastMessage = "";

    if (navigator.geolocation) {
      navigator.geolocation.getCurrentPosition(setPosition,
        locationError, options);
    }
    else {
      displayError("Update your browser to use Geolocation.");
    }
  }

  function setPosition(pos) {
    position = pos;

    if (successCallback) {
      successCallback(position);
    }
  }

  function locationError(error) {
    lastError = error;

    switch (error.code) {
      case error.PERMISSION_DENIED:
        lastMessage = "User does not want to display their location."
        break;
      case error.POSITION_UNAVAILABLE:
        lastMessage = "Can't determine user's location."
        break;
      case error.TIMEOUT:
        lastMessage = "The request for geolocation information timed out."
        break;
      case error.UNKNOWN_ERROR:
        lastMessage = "An unknown error occurred."
        break;
    }

    if (errorCallback) {
      errorCallback(lastMessage);
    }
  }

  // ************************************
  // Public Functions
  // ************************************
  return {
    "getCurrentLocation": function (success, error) {
      getCurrentLocation(success, error);
    },
    "getPosition": function () {
      return position;
    },
    "getLastError": function () {
      return lastError;
    },
    "getLastMessage": function () {
      return lastMessage;
    },
    "getOptions": function () {
      return options;
    },
    "setOptions": function (opts) {
      options = opts;
    }
  }
})();