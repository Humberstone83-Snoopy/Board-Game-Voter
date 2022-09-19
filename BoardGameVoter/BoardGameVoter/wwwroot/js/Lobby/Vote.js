"use strict";
(function () {

    var controls;
    var tableInputs;

    $(document).ready(function () {
        var voteTable = $('#VoteTable').dataTable({
            "processing": true,
            "filter": false,
            "paging": false,
            "columnDefs": [
                {
                    "targets": [0],
                    "visible": false,
                    "searchable": false
                },
                {
                    "targets": [8],
                    "sortable": false,
                    "searchable": false

                }
            ]
        });
    });

    function _bindEvents() {
        for (var propertyKey in tableInputs) {
            tableInputs[propertyKey].addEventListener("keypress", function (event) {
                event.preventDefault()
            });
            tableInputs[propertyKey].addEventListener("click", function (event) {
                _showRemainingVotes();
            });
        }
    }

    function _calculateVotesCast() {
        var totalVotesCast = 0;
        for (var propertyKey in tableInputs) {
            var inputValue = tableInputs[propertyKey].value
            if (inputValue != "") {
                totalVotesCast += parseInt(inputValue);
            }

        }
        return totalVotesCast;
    }

    function _init() {
        _setUpControls();
        _bindEvents();
        _showRemainingVotes();
        if (controls.action.value == "REDIRECT") {
            window.location.href = "/lobby/details";
        }
    }

    function _setUpControls() {
        controls = {
            action: document.getElementById("Action"),
            totalRowCount: document.getElementById("TotalRowCount"),
            remainingVotesLabel: document.getElementById("RemainingVotesLabel"),
            remainingVotes: document.getElementById("RemainingVotes")
        }
        tableInputs = {}
        for (var rowIndex = 0; rowIndex < parseInt(controls.totalRowCount.value); rowIndex++) {
            var propertyName = `voteInput${rowIndex}`;
            tableInputs = Object.assign(tableInputs, { [propertyName]: document.getElementById(`Votes_${rowIndex}_`) });
        }
    }

    function _showRemainingVotes() {
        controls.remainingVotesLabel.innerText = `${parseInt(controls.remainingVotes.value) - _calculateVotesCast()} Remaining`;
    }

    _init();
})();