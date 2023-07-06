
var maxQuantity = null;

$(document).ready(function () {

    
    //const dateTransportEl = document.querySelector('#dateTransport');
    const descriptionItemEl = document.querySelector('#descriptionItem');
    const locatorEl = document.querySelector('#locator');
    const lotEl = document.querySelector('#lot');
    const secondaryUnitEl = document.querySelector('#secondaryUnit');
    //const purposeOfTransportEl = document.querySelector('#purposeOfTransport');
    const quantityEl = document.querySelector('#quantity');

    const form = document.querySelector('#wizard-validation-form');

    const button1 = document.querySelector("#button1");
    const button2 = document.querySelector("#button2");


    const checklocator = () => {

        let valid = false;


     

    const checkdescriptionItem = () => {

        let valid = false;


        const descriptionItem = descriptionItemEl.value;//.trim();

        if (!isRequired(descriptionItem)) {
            showError(descriptionItemEl, 'يرجى تعبئة هذا الحقل');
        }
        else {
            showSuccess(descriptionItemEl);
            valid = true;
        }
        return valid;
    };


    const checkSecondaryUnit = () => {

        let valid = false;

        
        const secondaryUnit = secondaryUnitEl.value;//.trim();

        if (!isRequired(secondaryUnit)) {
            showError(secondaryUnitEl, 'يرجى تعبئة هذا الحقل');
        }
        else {
            showSuccess(secondaryUnitEl);
            valid = true;
        }
        return valid;
    };

    

    const checkQuantity = () => {

        let valid = false;
        
        var min = 0.1,
            max = maxQuantity;
        
        const quantity = quantityEl.value;//.trim();

        if (!isRequired(quantity)) {
            showError(quantityEl, 'يرجى تعبئة هذا الحقل');
        }
        //else if (maxQuantity == null) {
        //    showError(quantityEl, 'ادخل البيانات السابقة بطريقة صحيحة');
        //}
        //else if (!isBetween(quantity, min, max)) {
        //    showError(quantityEl, `يجب ان تكون الكمية ما بين ${min} و ${max}`)
        //}
        else {
            showSuccess(quantityEl);
            valid = true;
        }
        return valid;
    };

    const isRequired = value => value === '' ? false : true;
    const isBetween = (value, min, max) => value < min || value > max ? false : true;


    const showError = (input, message) => {
        // get the form-field element
        const formField = input.parentElement;
        // add the error class
        formField.classList.remove('success');
        formField.classList.add('error');

        // show the error message
        const error = formField.querySelector('small');
        error.textContent = message;
    };

    const showSuccess = (input) => {
        // get the form-field element
        const formField = input.parentElement;

        // remove the error class
        formField.classList.remove('error');
        formField.classList.add('success');

        // hide the error message
        const error = formField.querySelector('small');
        error.textContent = '';
    }


    button1.addEventListener('click', function (e) {
        // prevent the form from submitting
        e.preventDefault();

        // validate fields
        let isQuantityValid = checkQuantity(),
            isSecondaryUnitValid = checkSecondaryUnit(),
            isDescriptionItemValid = checkdescriptionItem(),




            //submitEl.setAttribute("id", "type-success");

            //  let isFormValid = isQuantityValid && isSecondaryUnitValid && isLotValid && isDescriptionItemValid && isLocatorValid;
            isFormValid = true;
        // submit to the server if the form is valid
        if (isFormValid) {
            
            form.submit();
            alert('تم الحفظ..!!');

            Swal.fire({
                title: 'تم الحفظ بنجاح',
                confirmButtonText: 'موافق',
                icon: 'success',
                customClass: {
                    confirmButton: 'btn btn-success',

                },
                buttonsStyling: false
            });
        }
    });

    button2.addEventListener('click', function (e) {
        // prevent the form from submitting
        e.preventDefault();

        // validate fields
        let isQuantityValid = checkQuantity(),
            isSecondaryUnitValid = checkSecondaryUnit(),
            isDescriptionItemValid = checkdescriptionItem(),



        //submitEl.setAttribute("id", "type-success");
        let isFormValid = isQuantityValid && isSecondaryUnitValid &&
            isLotValid && isDescriptionItemValid && isLocatorValid;
        // submit to the server if the form is valid
        let isFormValid = true;
        if (isFormValid) {

            form.submit();
            
            Swal.fire({
                title: 'تم حفظ الصنف السابق',
                confirmButtonText: 'موافق',
                icon: 'success',
                customClass: {
                    confirmButton: 'btn btn-success',

                },
                buttonsStyling: false
            });
        }
    });


    const debounce = (fn, delay = 500) => {
        let timeoutId;
        return (...args) => {
            // cancel the previous timer
            if (timeoutId) {
                clearTimeout(timeoutId);
            }
            // setup a new timer
            timeoutId = setTimeout(() => {
                fn.apply(null, args)
            }, delay);
        };
    };

    form.addEventListener('input', debounce(function (e) {
        switch (e.target.id) {
            case 'quantity':
                checkQuantity();
                break;
            //case 'purposeOfTransport':
            //    checkpurposeOfTransport();
            //    break;
            case 'secondaryUnit':
                checkSecondaryUnit();
                break;
            case 'lot':
                checkLot();
                break;
            case 'descriptionItem':
                checkdescriptionItem();
                break;
            case 'locator':
                checklocator();
                break;
            //case 'dateTransport':
            //    checkdateTransport();
            //    break;
        }
    }));

    


});