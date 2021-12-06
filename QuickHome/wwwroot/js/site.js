// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



function SearchProperties() {

    var searchCriteria = {};

    var stratumRangeValue = parseInt($("#stratumRange").val());
    if (stratumRangeValue > 0) {
        searchCriteria.stratum = { minimum: stratumRangeValue , maximum: stratumRangeValue };
    }

    var roomsRangeValue = parseInt($("#roomsRange").val());
    if (roomsRangeValue > 0) {
        searchCriteria.rooms = { minimum: roomsRangeValue, maximum: roomsRangeValue };
    }

    var bathroomsRangeValue = parseInt($("#bathroomsRange").val());
    if (bathroomsRangeValue > 0) {
        searchCriteria.bathrooms = { minimum: bathroomsRangeValue, maximum: bathroomsRangeValue };
    }

    var parkingSlotsRangeValue = parseInt($("#parkingSlotsRange").val());
    if (parkingSlotsRangeValue > 0) {
        searchCriteria.parkingSlots = { minimum: parkingSlotsRangeValue, maximum: parkingSlotsRangeValue };
    }

    var balconiesRangeValue = parseInt($("#balconiesRange").val());
    if (balconiesRangeValue > 0) {
        searchCriteria.balconies = { minimum: balconiesRangeValue, maximum: balconiesRangeValue };
    }

    var areaMinValue = parseInt($("#areaMin").val());
    var areaMaxValue = parseInt($("#areaMax").val());
    if (areaMinValue > 0 && isNaN(areaMaxValue)) {
        searchCriteria.area = { minimum: areaMinValue };
    } else if (isNaN(areaMinValue) && areaMaxValue > 0) {
        searchCriteria.area = { maximum: areaMaxValue };
    } else if (areaMinValue > 0 && areaMaxValue > 0) {
        searchCriteria.area = { minimum: areaMinValue, maximum: areaMaxValue };
    }

    var suggestedCanonMinValue = parseInt($("#suggestedCanonMin").val());
    var suggestedCanonMaxValue = parseInt($("#suggestedCanonMax").val());
    if (suggestedCanonMinValue > 0 && isNaN(suggestedCanonMaxValue)) {
        searchCriteria.suggestedCanon = { minimum: suggestedCanonMinValue };
    } else if (isNaN(suggestedCanonMinValue) && suggestedCanonMaxValue > 0) {
        searchCriteria.suggestedCanon = { maximum: suggestedCanonMaxValue };
    } else if (suggestedCanonMinValue > 0 && suggestedCanonMaxValue > 0) {
        searchCriteria.suggestedCanon = { minimum: suggestedCanonMinValue, maximum: suggestedCanonMinValue };
    }

    $.ajax({
        url: "/api/property/search",
        data: JSON.stringify(searchCriteria),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.propertyID + '</td>';
                html += '<td>' + item.address + '</td>';
                html += '<td>' + item.stratum + '</td>';
                html += '<td>' + item.area + '</td>';
                html += '<td>' + item.rooms + '</td>';
                html += '<td>' + item.bathrooms + '</td>';
                html += '<td>' + item.parkingSlots + '</td>';
                html += '<td>' + item.hasElevator + '</td>';
                html += '<td>' + item.balconies + '</td>';
                html += '<td>' + item.appraisal + '</td>';
                html += '<td>' + item.propertyType + '</td>';
                html += '<td>' + item.suggestedCanon + '</td>';
                html += '<td><a href="#" onclick="return requireRental(' + item.propertyID + ')">Require Rental</a> </td>';
                html += '</tr>';
            });
            $('#propertySearchTable tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}