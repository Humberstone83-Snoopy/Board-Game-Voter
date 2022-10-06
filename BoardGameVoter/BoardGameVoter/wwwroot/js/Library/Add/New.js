"use strict";
(function () {

    var controls;

    function _bindEvents() {
        controls.clear.addEventListener("click", function (event) {
            event.preventDefault();
            _clear();
        });
    }

    function _clear() {
        controls.title.value = "";
        controls.publisher.value = "";
        controls.releaseDate.value = "";
        controls.tagLine.value = "";
        controls.description.value = "";
        controls.weight.value = "";
        controls.ageRating.value = "";
        controls.maxPlayers.value = 0;
        controls.minPlayers.value = 0;
        controls.maxPlayTime.value = 0;
        controls.minPlayTime.value = 0;
        controls.pType.value = "";
        controls.sType.value = "";
        controls.pCategory.value = "";
        controls.sCategory.value = "";
        controls.tCategory.value = "";
        controls.pMechanism.value = "";
        controls.sMechanism.value = "";
        controls.tMechanism.value = "";
    }

    function _init() {

        _setUpControls();
        _bindEvents();
    }

    function _setUpControls() {
        controls = {
            clear: document.getElementById("Clear"),
            title: document.getElementById("TitleInput"),
            publisher: document.getElementById("PublisherInput"),
            releaseDate: document.getElementById("ReleaseDateInput"),
            tagLine: document.getElementById("TagLineInput"),
            description: document.getElementById("DescriptionInput"),
            weight: document.getElementById("WeightSelect"),
            ageRating: document.getElementById("AgeRatingInput"),
            maxPlayers: document.getElementById("MaxPlayersInput"),
            minPlayers: document.getElementById("MinPlayersInput"),
            maxPlayTime: document.getElementById("MaxPlayTimeInput"),
            minPlayTime: document.getElementById("MinPlayTimeInput"),
            pType: document.getElementById("PrimaryTypeSelect"),
            sType: document.getElementById("SecondaryTypeSelect"),
            pCategory: document.getElementById("PrimaryCategorySelect"),
            sCategory: document.getElementById("SecondaryCategorySelect"),
            tCategory: document.getElementById("TertiaryCategorySelect"),
            pMechanism: document.getElementById("PrimaryMechanismSelect"),
            sMechanism: document.getElementById("SecondaryMechanismSelect"),
            tMechanism: document.getElementById("TertiaryMechanismSelect")
        };
    }

    _init();
})();