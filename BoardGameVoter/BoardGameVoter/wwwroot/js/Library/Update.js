"use strict";
(function () {

    var controls;

    function _bindEvents() {
        controls.delete.addEventListener("click", function () {
            controls.action.value = "DELETE";
            controls.form.submit();
        });
        controls.edit?.addEventListener("click", function () {
            controls.disableInputs.value = false;
            controls.form.submit();
        });
        controls.save?.addEventListener("click", function () {
            controls.disableInputs.value = true;
            controls.action.value = "SAVE";
            controls.form.submit();
        });
        controls.return.addEventListener("click", function (event) {
            _return(event);
        });
    }

    function _init() {

        _setUpControls();
        _bindEvents();

        if (controls.action.value == "REDIRECT") {
            _return();
        }
    }

    function _return(event) {
        event.preventDefault();
        window.location.href = "/library";
    }

    function _setUpControls() {
        controls = {
            action: document.getElementById("Action"),
            form: document.getElementById("Update"),
            nickname: document.getElementById("NicknameInput"),
            title: document.getElementById("TitleInput"),
            description: document.getElementById("DescriptionInput"),
            difficulty: document.getElementById("DifficultySelect"),
            maxPlayers: document.getElementById("MaxPlayersInput"),
            minPlayers: document.getElementById("MinPlayersInput"),
            maxPlayTime: document.getElementById("MaxPlayTimeInput"),
            minPlayTime: document.getElementById("MinPlayTimeInput"),
            disableInputs: document.getElementById("DisableInputs"),
            publisher: document.getElementById("PublisherInput"),
            active: document.getElementById("Active"),
            edit: document.getElementById("Edit"),
            delete: document.getElementById("Delete"),
            save: document.getElementById("Save"),
            return: document.getElementById("Return")
        };
    }

    _init();
})();