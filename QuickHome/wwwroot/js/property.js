//Load Data in Table when documents is ready  
$(document).ready(function () {
    loadPropertyData();
});

//Load Data function  
function loadPropertyData() {
    $.ajax({
        url: "/api/property/search",
        type: "GET",
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
                html += '<td>' + item.lessor.fullName + '</td>';
                html += '<td><a href="#" onclick="return getPropertyByID(' + item.propertyID + ')">Edit</a> </td>';
                html += '</tr>';
            });
            $('#propertyTable tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//Add Data Function   
function AddProperty() {
    var res = validateProperty();
    if (res == false) {
        return false;
    }

    var hasElevator = $('#HasElevator').val();
    var propertyObj = {
        propertyID: parseInt($('#PropertyID').val()),
        address: $('#Address').val(),
        stratum: parseInt($('#Stratum').val()),
        area: parseInt($('#Area').val()),
        rooms: parseInt($('#Rooms').val()),
        bathrooms: parseInt($('#Bathrooms').val()),
        parkingSlots: parseInt($('#ParkingSlots').val()),
        hasElevator: hasElevator === "true" ? true : false,
        balconies: parseInt($('#Balconies').val()),
        appraisal: parseInt($('#Appraisal').val()),
        propertyType: parseInt($('#PropertyType').val()),
        suggestedCanon: parseInt($('#SuggestedCanon').val()),
        lessorID: parseInt($('#LessorID').val())
    };
    $.ajax({
        url: "/api/property",
        data: JSON.stringify(propertyObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadPropertyData();
            $('#myModal').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//Function for getting the Data Based upon Employee ID  
function getPropertyByID(propertyId) {
    $('#PropertyID').css('border-color', 'lightgrey');
    $('#Address').css('border-color', 'lightgrey');
    $('#Stratum').css('border-color', 'lightgrey');
    $('#Area').css('border-color', 'lightgrey');
    $('#Rooms').css('border-color', 'lightgrey');
    $('#Bathrooms').css('border-color', 'lightgrey');
    $('#ParkingSlots').css('border-color', 'lightgrey');
    $('#HasElevator').css('border-color', 'lightgrey');
    $('#Balconies').css('border-color', 'lightgrey');
    $('#Appraisal').css('border-color', 'lightgrey');
    $('#PropertyType').css('border-color', 'lightgrey');
    $('#SuggestedCanon').css('border-color', 'lightgrey');
    $('#LessorID').css('border-color', 'lightgrey');
    $.ajax({
        url: "/api/property/search/" + propertyId,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#PropertyID').val(result.propertyID);
            $('#Address').val(result.address);
            $('#Stratum').val(result.stratum);
            $('#Area').val(result.area);
            $('#Rooms').val(result.rooms);
            $('#Bathrooms').val(result.bathrooms);
            $('#ParkingSlots').val(result.parkingSlots);
            $('#HasElevator').val(result.hasElevator);
            $('#Balconies').val(result.balconies);
            $('#Appraisal').val(result.appraisal);
            $('#PropertyType').val(result.propertyType);
            $('#SuggestedCanon').val(result.suggestedCanon);
            $('#LessorID').val(result.lessorID);

            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

//function for updating employee's record  
function UpdateProperty() {
    var res = validateProperty();
    if (res == false) {
        return false;
    }
    var hasElevator = $('#HasElevator').val();
    var propertyObj = {
        propertyID: parseInt($('#PropertyID').val()),
        address: $('#Address').val(),
        stratum: parseInt($('#Stratum').val()),
        area: parseInt($('#Area').val()),
        rooms: parseInt($('#Rooms').val()),
        bathrooms: parseInt($('#Bathrooms').val()),
        parkingSlots: parseInt($('#ParkingSlots').val()),
        hasElevator: hasElevator === "true" ? true : false,
        balconies: parseInt($('#Balconies').val()),
        appraisal: parseInt($('#Appraisal').val()),
        propertyType: parseInt($('#PropertyType').val()),
        suggestedCanon: parseInt($('#SuggestedCanon').val()),
        lessorID: parseInt($('#LessorID').val())
    };
    $.ajax({
        url: "/api/property/" + propertyObj.propertyID,
        data: JSON.stringify(propertyObj),
        type: "PUT",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadPropertyData();
            $('#myModal').modal('hide');
            $('#PropertyID').val("");
            $('#Address').val("");
            $('#Stratum').val("");
            $('#Area').val("");
            $('#Rooms').val("");
            $('#Bathrooms').val("");
            $('#ParkingSlots').val("");
            $('#HasElevator').val("");
            $('#Balconies').val("");
            $('#Appraisal').val("");
            $('#PropertyType').val("");
            $('#SuggestedCanon').val("");
            $('#LessorID').val("");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//Function for clearing the textboxes  
function clearTextBox() {
    $('#PropertyID').val("");
    $('#Address').val("");
    $('#Stratum').val("");
    $('#Area').val("");
    $('#Rooms').val("");
    $('#Bathrooms').val("");
    $('#ParkingSlots').val("");
    $('#HasElevator').val("");
    $('#Balconies').val("");
    $('#Appraisal').val("");
    $('#PropertyType').val("");
    $('#SuggestedCanon').val("");
    $('#LessorID').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#PropertyID').css('border-color', 'lightgrey');
    $('#Address').css('border-color', 'lightgrey');
    $('#Stratum').css('border-color', 'lightgrey');
    $('#Area').css('border-color', 'lightgrey');
    $('#Rooms').css('border-color', 'lightgrey');
    $('#Bathrooms').css('border-color', 'lightgrey');
    $('#ParkingSlots').css('border-color', 'lightgrey');
    $('#HasElevator').css('border-color', 'lightgrey');
    $('#Balconies').css('border-color', 'lightgrey');
    $('#Appraisal').css('border-color', 'lightgrey');
    $('#PropertyType').css('border-color', 'lightgrey');
    $('#SuggestedCanon').css('border-color', 'lightgrey');
    $('#LessorID').css('border-color', 'lightgrey');
}
//Valdidation using jquery  
function validateProperty() {
    var isValid = true;
    if ($('#PropertyID').val().trim() == "") {
        $('#PropertyID').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#PropertyID').css('border-color', 'lightgrey');
    }
    if ($('#Address').val().trim() == "") {
        $('#Address').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Address').css('border-color', 'lightgrey');
    }
    if ($('#Stratum').val().trim() == "") {
        $('#Stratum').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Stratum').css('border-color', 'lightgrey');
    }
    if ($('#Area').val().trim() == "") {
        $('#Area').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Area').css('border-color', 'lightgrey');
    }
    if ($('#Rooms').val().trim() == "") {
        $('#Rooms').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Rooms').css('border-color', 'lightgrey');
    }
    if ($('#Bathrooms').val().trim() == "") {
        $('#Bathrooms').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Bathrooms').css('border-color', 'lightgrey');
    }
    if ($('#ParkingSlots').val().trim() == "") {
        $('#ParkingSlots').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#ParkingSlots').css('border-color', 'lightgrey');
    }
    if ($('#HasElevator').val().trim() == "") {
        $('#HasElevator').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#HasElevator').css('border-color', 'lightgrey');
    }
    if ($('#Balconies').val().trim() == "") {
        $('#Balconies').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Balconies').css('border-color', 'lightgrey');
    }
    if ($('#Appraisal').val().trim() == "") {
        $('#Appraisal').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Appraisal').css('border-color', 'lightgrey');
    }
    if ($('#PropertyType').val().trim() == "") {
        $('#PropertyType').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#PropertyType').css('border-color', 'lightgrey');
    }
    if ($('#SuggestedCanon').val().trim() == "") {
        $('#SuggestedCanon').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#SuggestedCanon').css('border-color', 'lightgrey');
    }
    if ($('#LessorID').val().trim() == "") {
        $('#LessorID').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#LessorID').css('border-color', 'lightgrey');
    }
    return isValid;
}