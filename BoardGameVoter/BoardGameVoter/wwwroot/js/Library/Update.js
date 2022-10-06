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
    }

    function _init() {

        _setUpControls();
        _bindEvents();
    }

    function _setUpControls() {
        controls = {
            action: document.getElementById("Action"),
            form: document.getElementById("Update"),
            disableInputs: document.getElementById("DisableInputs"),
            active: document.getElementById("Active"),
            edit: document.getElementById("Edit"),
            delete: document.getElementById("Delete"),
            save: document.getElementById("Save")
        };
    }

    _init();
})();