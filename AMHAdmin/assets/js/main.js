/*
* My Watchman
* @version: 1.0.0
* @author: Uichamp
* @license: Uichamp (https://uichamp.com/licenses)
* Copyright 2021 Uichamp
*/
(function () {
  'use strict';

  var tooltip = function () {
    $('[data-toggle="tooltip"]').tooltip();
  }();

  var popover = function () {
    $('[data-toggle="popover"]').popover();
  }();

  var toggleSidebar = function () {
    if ($(window).width() < 1200) {
      $("body").addClass("aside-closed-mode");
    } else {
      $("body").removeClass("aside-closed-mode");
    }

    if ($(window).width() < 1200) {
      $(".toggle-sidebar").click(function () {
        $("body").toggleClass("aside-closed-mode");
        $(".backdrop").removeClass("d-none");
      });
    } else {
      $(".toggle-sidebar").click(function () {
        $("body").toggleClass("aside-closed-mode");
        $(".backdrop").addClass("d-none");
      });
    }

    $(".backdrop").click(function () {
      $("body").toggleClass("aside-closed-mode");
      $(".backdrop").addClass("d-none");
    });
  }();
})();