document.getElementById("psw").addEventListener("keyup", (event) => {
    var isAnyInvalid = false;
    var inputParameters = [
        {
            param: document.getElementById("letter"),
            regex: /[a-z]/g
        },
        {
            param: document.getElementById("capital"),
            regex: /[A-Z]/g
        },
        {
            param: document.getElementById("number"),
            regex: /[0-9]/g
        },
        {
            param: document.getElementById("length"),
            regex: /.{8,}/g
        }
    ];

    for (let i = 0; i < inputParameters.length; i++)
    {
        if (!event.target.value.match(inputParameters[i].regex)) {

            inputParameters[i].param.classList.remove("valid");
            inputParameters[i].param.classList.add("invalid");
            isAnyInvalid = true;
        } else {
            inputParameters[i].param.classList.remove("invalid");
            inputParameters[i].param.classList.add("valid");
        }
    }

    if (isAnyInvalid) {
        document.getElementById("successPassword").innerText = "Ваш пароль не соответствует требуемым критериям!";
    } else {
        document.getElementById("successPassword").innerText = "Ваш пароль прекрасен! Тыкай!";
    }
});



document.getElementById("userForm").addEventListener("submit", async (event) => {
    event.preventDefault();
    var myFormData = new FormData(event.target);

    var user = {};
    myFormData.forEach((value, key) => (user[key] = value));
    console.log(user);

    let response = await fetch('/registration', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json;charset=utf-8'
        },
        body: JSON.stringify(user)
    });

    if (response.ok) {
        window.resultMessage.innerText = "Успешное сохранение клиента. " +
            "Через пару секунд вы будете перенаправлены на главную страницу";
        setTimeout(function () {
            window.location.href = "/home";
        }, 2000);
    }
    else {
        window.resultMessage.innerText = `Увы, во время сохранение пользователя произошла непредвиденная ошибка.` +
            `Информация по ошибке ${result.message}`;
    }
});
