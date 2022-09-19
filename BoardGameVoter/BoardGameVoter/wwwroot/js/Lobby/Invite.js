"use strict";
(function () {

    var controls;

    function _bindEvents() {
        controls.add.addEventListener("click", function () {
            controls.action.value = "ADD";
            controls.form.submit();
        });
        controls.complete.addEventListener("click", function (event) {
            event.preventDefault();
            window.location.href = "/lobby/vote/" + controls.voteSessionUID.value
        });
    }

    function _init() {
        _setUpControls();
        _bindEvents();
    }

    function _setUpControls() {
        controls = {
            action: document.getElementById("Action"),
            add: document.getElementById("Add"),
            form: document.getElementById("InviteForm"),
            complete: document.getElementById("Complete"),
            voteSessionUID: document.getElementById("VoteSessionUID"),
        };
    }

    _init();
})();