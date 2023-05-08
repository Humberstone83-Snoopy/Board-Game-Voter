"use strict";
(function () {

    $(document).ready(function () {
        var newGameDatatable = $('#NewGameDatatable').dataTable({
            "filter": false,
            "pagingType": 'full_numbers',
            "columns":
                [
                    { "data": "image", },
                    { "data": "title"},
                    { "data": "releaseDate" },
                    {
                        "data": "action",
                        "orderable": false
                    }
                ]
        });
    });

    //$('#NewGameDatatable').on('click', 'td.newGameDatatable-edit', function (e) {
    //    e.preventDefault();

    //    _addGame($(this).closest('tr').id);
    //});

    //let control_addNewPostForm = document.getElementById("AddNew"),
    //    control_boardGameGeekID = document.getElementById("BoardGameGeekID");

    //function _setHandler(formElement, handler) {
    //    formElement.setAttribute('action', `${formElement.action}?handler=${handler}`);
    //}

    //function _addGame(boardGameGeekID) {
    //    //TODO: Fill
    //    _setHandler(control_addNewPostForm, "AddBoardGame");
    //    control_boardGameGeekID.value = boardGameGeekID;
    //    control_addNewPostForm.submit();
    //}

    function _init() {
    }

    _init();
})();