/**
 *  Form Wizard
 */

'use strict';

(function () {

  const flatPickrList = [].slice.call(document.querySelectorAll('.flatpickr-validation'));
  // Flat pickr
  if (flatPickrList) {
    flatPickrList.forEach(flatPickr => {
      flatPickr.flatpickr({
        allowInput: true,
        monthSelectorType: 'static'
      });
    });
  }

  // Wizard Validation
  // --------------------------------------------------------------------
  const wizardValidation = document.querySelector('#wizard-validation');
  if (typeof wizardValidation !== undefined && wizardValidation !== null) {
    // Wizard form
    const wizardValidationForm = wizardValidation.querySelector('#wizard-validation-form');
    // Wizard steps
    const wizardValidationFormStep1 = wizardValidationForm.querySelector('#newTransport');
    const wizardValidationFormStep2 = wizardValidationForm.querySelector('#addItems');
    //const wizardValidationFormStep3 = wizardValidationForm.querySelector('#social-links-validation');
    // Wizard next prev button
    const wizardValidationNext = [].slice.call(wizardValidationForm.querySelectorAll('.btn-next'));
    const wizardValidationPrev = [].slice.call(wizardValidationForm.querySelectorAll('.btn-prev'));

    const validationStepper = new Stepper(wizardValidation, {
      linear: true
    });

    // Account details
    const FormValidation1 = FormValidation.formValidation(wizardValidationFormStep1, {
      fields: { 
        purposeOfTransport: {
          validators: {
            notEmpty: {
              message: 'يرجى تعبئة هذا الحقل'
            },
            regexp: {
              regexp: /^[a-zA-Zأ-ي ]+$/,
              message: 'يجب ادخال احرف  فقط'
            }
          }
         
        },
        dateTransport: {
          validators: {
            notEmpty: {
              message:'يرجى تعبئة هذا الحقل'
            }
          }
        },
        mainStore: {
          validators: {
            notEmpty: {
              message:' يرجى اختيار مخزن '
            }
          }
        },
        mainStore1: {
          validators: {
            notEmpty: {
              message: ' يرجى اختيار مخزن '
            }
          }
        },
        State: {
          validators: {
            notEmpty: {
              message: 'يرجى تعبئة هذا الحقل'
            }
          }
        }
      },
      plugins: {
        trigger: new FormValidation.plugins.Trigger(),
        bootstrap5: new FormValidation.plugins.Bootstrap5({
          // Use this for enabling/changing valid/invalid class
          // eleInvalidClass: '',
          eleValidClass: '',
          rowSelector: '.col-sm-3'
        }),
        autoFocus: new FormValidation.plugins.AutoFocus(),
        submitButton: new FormValidation.plugins.SubmitButton()
      },
      init: instance => {
        instance.on('plugins.message.placed', function (e) {
          //* Move the error message out of the `input-group` element
          if (e.element.parentElement.classList.contains('input-group')) {
            e.element.parentElement.insertAdjacentElement('afterend', e.messageElement);
          }
        });
      }
    }).on('core.form.valid', function () {
      // Jump to the next step when all fields in the current step are valid
      validationStepper.next();
    });

    // Personal info
    const FormValidation2 = FormValidation.formValidation(wizardValidationFormStep2, {
      fields: { 
        itemGroupA:{
        validators: {
          notEmpty: {
            message: ' يرجى اختيار مجموعة '
          }
        }
      },
      itemGroupB:{
        validators: {
          notEmpty: {
            message: ' يرجى اختيار مجموعة '
          }
        }
      },
      itemGroupC:{
        validators: {
          notEmpty: {
            message: ' يرجى اختيار مجموعة '
          }
        }
      },
      descriptionItem: {
        validators: {
          notEmpty: {
            message: ' يرجى تعبئة هذا الحقل '
          }
        }
      },
      subStoreA:{
        validators: {
          notEmpty: {
            message: ' يرجى اختيار مخزن '
          }
        }
      },
      subStoreB:{
        validators: {
          notEmpty: {
            message: ' يرجى اختيار مخزن '
          }
        }
      },
      subStoreC:{
        validators: {
          notEmpty: {
            message: ' يرجى اختيار مخزن '
          }
        }
      },
      locator:{
        validators: {
          notEmpty: {
            message: ' يرجى اختيار مخزن '
          }
        }
      },
      quantity:{
        validators: {
          notEmpty: {
            message: ' يرجى تعبئة هذا الحقل '
          },
          stringLength: {
            min: 1,
            max: 1000,
           message: 'يجب ان تكون الكمية اكثر من 1 واقل من 1000 '
         },
         regexp: {
          regexp: /^[0-9]+$/,
           message: 'يجب ادخال أرقام موجبة  فقط'
         }
        }
      },
      secondaryUnit:{
        validators: {
          notEmpty: {
            message: ' يرجى تعبئة هذا الحقل '
          },
           
           regexp: {
             regexp: /^[a-zA-Zأ-ي ]+$/,
             message: 'يجب ادخال احرف  فقط'
           }
        }
      }
    },
      plugins: {
        trigger: new FormValidation.plugins.Trigger(),
        bootstrap5: new FormValidation.plugins.Bootstrap5({
          // Use this for enabling/changing valid/invalid class
          // eleInvalidClass: '',
          eleValidClass: '',
          rowSelector: '.col-12'
        }),
        autoFocus: new FormValidation.plugins.AutoFocus(),
        submitButton: new FormValidation.plugins.SubmitButton()
      }
    }).on('core.form.valid', function () {
        // You can submit the form
        // wizardValidationForm.submit()
        // or send the form data to server via an Ajax request
        // To make the demo simple, I just placed an alert
        // alert('Submitted..!!');
      });

   

    wizardValidationNext.forEach(item => {
      item.addEventListener('click', event => {
        // When click the Next button, we will validate the current step
        switch (validationStepper._currentIndex) {
          case 0:
            FormValidation1.validate();
            break;

          case 1:
            FormValidation2.validate();
            break;

          default:
            break;
        }
      });
    });

    wizardValidationPrev.forEach(item => {
      item.addEventListener('click', event => {
        switch (validationStepper._currentIndex) {
        
          case 1:
            validationStepper.previous();
            break;

          case 0:

          default:
            break;
        }
      });
    });
  }
})();
