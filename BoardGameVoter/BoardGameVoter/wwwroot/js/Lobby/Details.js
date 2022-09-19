"use strict";
(function () {

    var controls;

    function _bindEvents() {
        controls.closeVote?.addEventListener("click", function () {
            controls.action.value = "CLOSEVOTE";
            controls.form.submit();
        });

        controls.deleteAttendee?.addEventListener("click", function () {
            controls.action.value = "DELETEATTENDEE";
            controls.form.submit();
        });

        controls.deleteSession?.addEventListener("click", function () {
            controls.action.value = "DELETESESSION";
            controls.form.submit();
        });
    }

    function _init() {
        _setUpControls();
        _bindEvents();
        _handleRedirect();
    }

    function _handleRedirect() {
        if (controls.action.value == "REDIRECT") {
            window.location.href = "/lobby";
        }
    }

    function _setUpControls() {
        controls = {
            action: document.getElementById("Action"),
            closeVote: document.getElementById("CloseVote"),
            deleteAttendee: document.getElementById("DeleteAttendee"),
            deleteSession: document.getElementById("DeleteSession"),
            form: document.getElementById("DetailsForm"),
            voteSessionUID: document.getElementById("VoteSessionUID"),
        };
    }

    _init();
})();