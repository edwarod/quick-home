//Load Data in Table when documents is ready  
$(document).ready(function () {
    loadLessorData();
});

//Load Data function  
function loadLessorData() {
    $.ajax({
        url: "/api/lessor",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.id + '</td>';
                html += '<td>' + item.lastName + '</td>';
                html += '<td>' + item.firstMidName + '</td>';
                html += '<td>' + item.fullName + '</td>';
                html += '<td>' + item.birthDate + '</td>';
                html += '<td><a href="#" onclick="return getLessorByID(' + item.id + ')">Edit</a> | <a href="#" onclick="DeleteLessor(' + item.id + ')">Delete</a></td>';
                html += '</tr>';
            });
            $('#lessorTable tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//Add Data Function   
function AddLessor() {
    var res = validateLessor();
    if (res == false) {
        return false;
    }
    var lessorObj = {
        id: parseInt($('#ID').val()),
        lastName: $('#LastName').val(),
        firstMidName: $('#FirstMidName').val(),
        birthDate: $('#BirthDate').val()
    };
    $.ajax({
        url: "/api/lessor",
        data: JSON.stringify(lessorObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadLessorData();
            $('#myModal').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//Function for getting the Data Based upon Employee ID  
function getLessorByID(lessorId) {
    $('#LastName').css('border-color', 'lightgrey');
    $('#FirstMidName').css('border-color', 'lightgrey');
    $('#BirthDate').css('border-color', 'lightgrey');
    $.ajax({
        url: "/api/lessor/" + lessorId,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#ID').val(result.id);
            $('#LastName').val(result.lastName);
            $('#FirstMidName').val(result.firstMidName);
            $('#BirthDate').val(result.birthDate);

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
function UpdateLessor() {
    var res = validateLessor();
    if (res == false) {
        return false;
    }
    var lessorObj = {
        id: parseInt($('#ID').val()),
        lastName: $('#LastName').val(),
        firstMidName: $('#FirstMidName').val(),
        birthDate: $('#BirthDate').val()
    };
    $.ajax({
        url: "/api/lessor/" + lessorObj.id,
        data: JSON.stringify(lessorObj),
        type: "PUT",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadLessorData();
            $('#myModal').modal('hide');
            $('#ID').val("");
            $('#LastName').val("");
            $('#FirstMidName').val("");
            $('#BirthDate').val("");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//function for deleting employee's record  
function DeleteLessor(ID) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "/api/lessor/" + ID,
            type: "DELETE",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                loadLessorData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}

//Function for clearing the textboxes  
function clearTextBox() {
    $('#ID').val("");
    $('#LastName').val("");
    $('#FirstMidName').val("");
    $('#BirthDate').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#LastName').css('border-color', 'lightgrey');
    $('#FirstMidName').css('border-color', 'lightgrey');
    $('#BirthDate').css('border-color', 'lightgrey');
}
//Valdidation using jquery  
function validateLessor() {
    var isValid = true;
    if ($('#LastName').val().trim() == "") {
        $('#LastName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#LastName').css('border-color', 'lightgrey');
    }
    if ($('#FirstMidName').val().trim() == "") {
        $('#FirstMidName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#FirstMidName').css('border-color', 'lightgrey');
    }
    if ($('#BirthDate').val().trim() == "") {
        $('#BirthDate').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#BirthDate').css('border-color', 'lightgrey');
    }
    return isValid;
}