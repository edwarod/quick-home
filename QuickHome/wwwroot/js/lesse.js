//Load Data in Table when documents is ready  
$(document).ready(function () {
    loadLesseeData();
});

//Load Data function  
function loadLesseeData() {
    $.ajax({
        url: "/api/lessee",
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
                html += '<td>' + item.monthlyIncome + '</td>';
                html += '<td><a href="#" onclick="return getLesseeByID(' + item.id + ')">Edit</a> | <a href="#" onclick="DeleteLessee(' + item.id + ')">Delete</a></td>';
                html += '</tr>';
            });
            $('#lesseTable tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//Add Data Function   
function AddLessee() {
    var res = validateLessee();
    if (res == false) {
        return false;
    }
    var lesseeObj = {
        id: parseInt($('#ID').val()),
        lastName: $('#LastName').val(),
        firstMidName: $('#FirstMidName').val(),
        birthDate: $('#BirthDate').val(),
        monthlyIncome: parseInt($('#MonthlyIncome').val())
    };
    $.ajax({
        url: "/api/lessee",
        data: JSON.stringify(lesseeObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadLesseeData();
            $('#myModal').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//Function for getting the Data Based upon Employee ID  
function getLesseeByID(lesseeId) {
    $('#LastName').css('border-color', 'lightgrey');
    $('#FirstMidName').css('border-color', 'lightgrey');
    $('#BirthDate').css('border-color', 'lightgrey');
    $('#MonthlyIncome').css('border-color', 'lightgrey');
    $.ajax({
        url: "/api/lessee/" + lesseeId,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#ID').val(result.id);
            $('#LastName').val(result.lastName);
            $('#FirstMidName').val(result.firstMidName);
            $('#BirthDate').val(result.birthDate);
            $('#MonthlyIncome').val(result.monthlyIncome);

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
function UpdateLessee() {
    var res = validateLessee();
    if (res == false) {
        return false;
    }
    var lesseeObj = {
        id: parseInt($('#ID').val()),
        lastName: $('#LastName').val(),
        firstMidName: $('#FirstMidName').val(),
        birthDate: $('#BirthDate').val(),
        monthlyIncome: parseInt($('#MonthlyIncome').val())
    };
    $.ajax({
        url: "/api/lessee/" + lesseeObj.id,
        data: JSON.stringify(lesseeObj),
        type: "PUT",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadLesseeData();
            $('#myModal').modal('hide');
            $('#ID').val("");
            $('#LastName').val("");
            $('#FirstMidName').val("");
            $('#BirthDate').val("");
            $('#MonthlyIncome').val("");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//function for deleting employee's record  
function DeleteLessee(ID) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "/api/lessee/" + ID,
            type: "DELETE",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                loadLesseeData();
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
    $('#MonthlyIncome').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#LastName').css('border-color', 'lightgrey');
    $('#FirstMidName').css('border-color', 'lightgrey');
    $('#BirthDate').css('border-color', 'lightgrey');
    $('#MonthlyIncome').css('border-color', 'lightgrey');
}
//Valdidation using jquery  
function validateLessee() {
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
    if ($('#MonthlyIncome').val().trim() == "") {
        $('#MonthlyIncome').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#MonthlyIncome').css('border-color', 'lightgrey');
    }
    return isValid;
}