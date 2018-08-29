function hideAgeColumn() {
    var ageColumn = document.getElementById("hideAge");
    if (ageColumn.style.display === "none") {
        ageColumn.style.display = "block";
    } else {
        ageColumn.style.display = "none";
    }
}

function validatePhone() {
  
    var phoneNumber = document.getElementById("PhoneNumber").value;
    var phoneFilter = /[0-9]{8,10}$/;

    if (!phoneFilter.test(phoneNumber)) {
        $("#validePhoneNumber").removeClass('hidden');
        document.getElementById('PhoneNumber').style.borderColor = "red";
        return false;
    }
    else {
        $("#validePhoneNumber").addClass('hidden');
        document.getElementById('PhoneNumber').style.borderColor = "green";
        return true;
    }
}

function validateForm() {
    var x = document.getElementById("invalidEmail").value;

    var filter = /^[\w\-\.\+]+\@[a-zA-Z0-9\.\-]+\.[a-zA-z0-9]{2,4}$/;
    if (!filter.test(x))
    {
        $("#valideEmail").removeClass('hidden');

        document.getElementById('invalidEmail').style.borderColor = "red";
        return false;
    }
    else
    {
        $("#valideEmail").addClass('hidden');
        document.getElementById('invalidEmail').style.borderColor = "green";

        return true;
    }
}


function validatePassword()
{
    var samePassword = $('#Password2').val();
    var secondPassword = $('#Password').val();

    if (samePassword == secondPassword)
    {
        $("#passwordMisMatach").addClass('hidden');
        $("#passwordCheck").removeClass('has-error');
        return true;
    }
    else
    {
        $("#passwordMisMatach").removeClass('hidden');
        $("#passwordCheck").addClass('has-error');
        return false;
    }

}

function passwordValidation() {
    var sPassword = $('#Password').val();
    if ($.trim(sPassword).length == 0)
    {
        $("#passwordNull").removeClass('hidden');
        $("#passwordCheck").addClass('has-error');
    }
    else
    {
        $("#passwordNull").addClass('hidden');
        $("#passwordCheck").removeClass('has-error');
        if (!validatePasswordTesting(sPassword))
        {
            $("#passwordError").removeClass('hidden');
            $("#passwordCheck").addClass('has-error');
        }
        else
        {
            $("#passwordError").addClass('hidden');
            $("#passwordCheck").removeClass('has-error');
        }
    }
}
function validatePasswordTesting(password)
{
    var len = password.length;
    if (len < 8) { return false; }
    var re = /[0-9]/;
    var re1 = /[a-z]/;
    var re2 = /[A-Z]/;
    var re3 = /[!&\/=?_.,:;\-^<>%$#%@|]/;
    var count = 0;
    if (re.test(password))
    {
        count = count + 1;
    }
    if (re1.test(password))
    {
        count = count + 1;
    }
    if (re2.test(password))
    {
        count = count + 1;
    }
    if (re3.test(password))
    {
        count = count + 1;
    }
    if (count > 2)
    {
        return true;
    }
    return false;
}
function displayVideoGameOptions() {
    var gameSystemValue = $("#gameSystem").val();
    if (gameSystemValue == 'PS4') {
        $("#ps4Game").removeClass('hidden');
        $("#xbox").addClass('hidden');
        $("#noGame").addClass('hidden');
    } else if (gameSystemValue == 'XBoxOne') {
        $("#xbox").removeClass('hidden');
        $("#ps4Game").addClass('hidden');
        $("#noGame").addClass('hidden');
    } else if (gameSystemValue.length == 0) {
        $("#noGame").removeClass('hidden');
        $("#xbox").addClass('hidden');
        $("#ps4Game").addClass('hidden');
    }
}

function verifyAge(event) {
    var ageEntered = event.currentTarget.value;
    var num = isInt(ageEntered);
    var numF = isFloat(ageEntered);
    if (num || numF)
    {
        $("#valideNumber18Error").addClass('hidden');
        if (ageEntered >= 18) {
            $("#hideAge").addClass('has-error');
            $("#below18Error").removeClass('hidden');         
        } else {
            $("#hideAge").removeClass('has-error');
            $("#below18Error").addClass('hidden');       
        }
    }
    else
    {
        $("#below18Error").addClass('hidden'); 
        $("#valideNumber18Error").removeClass('hidden');

    }
}

function isInt(n)
{
    return Number(n) == n && n % 1 == 0;
}

function isFloat(n)
{
    return Number(n) == n && n % 1 !== 0;
}


