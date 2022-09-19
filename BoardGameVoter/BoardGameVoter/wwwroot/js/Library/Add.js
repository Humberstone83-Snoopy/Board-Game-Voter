"use strict";
(function () {

    var controls;

    function _bindEvents() {
        controls.find.addEventListener("click", function () {
            controls.action.value = "FIND";
            controls.form.submit();
        });
        controls.complete.addEventListener("click", function () {
            controls.action.value = "COMPLETE";
            controls.form.submit();
        });
        controls.clear.addEventListener("click", function () {
            _clear();
        });
    }

    function _clear() {
        controls.title.value = "";
        controls.description.value = "";
        controls.difficulty.value = "";
        controls.publisher.value = "";
        controls.maxPlayers.value = 0;
        controls.minPlayers.value = 0;
        controls.maxPlayTime.value = 0;
        controls.minPlayTime.value = 0;
        controls.disableInputs.value = false;
    }

    function _init() {

        _setUpControls();
        _bindEvents();

        if (controls.action.value == "REDIRECT") {
            window.location.href = "/library";
        }
    }

    function _setUpControls() {
        controls = {
            find: document.getElementById("Find"),
            complete: document.getElementById("Complete"),
            action: document.getElementById("Action"),
            form: document.getElementById("AddNew"),
            title: document.getElementById("TitleInput"),
            description: document.getElementById("DescriptionInput"),
            difficulty: document.getElementById("DifficultySelect"),
            maxPlayers: document.getElementById("MaxPlayersInput"),
            minPlayers: document.getElementById("MinPlayersInput"),
            maxPlayTime: document.getElementById("MaxPlayTimeInput"),
            minPlayTime: document.getElementById("MinPlayTimeInput"),
            clear: document.getElementById("Clear"),
            disableInputs: document.getElementById("DisableInputs"),
            publisher: document.getElementById("PublisherInput")
        };
    }

    _init();
})();