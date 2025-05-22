window.initializeDataTable = (tableId) => {
    //jQuery.noConflict();
    jQuery(function ($) {
        console.log("Initializing DataTable for: " + tableId);
        $('#' + tableId).DataTable(
        );
    });
};