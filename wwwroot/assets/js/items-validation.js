/**
 *  Form Wizard
 */

'use strict';

(function () {
  // Init custom option check
  window.Helpers.initCustomOptionCheck();

 
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
  const  numeralMask = document.querySelector('.numeral1');
  //Numeral
 if (numeralMask) {
  new Cleave(numeralMask, {
    numeral: true,
    numeralThousandsGroupStyle: 'thousand'
  });
}

  // Vertical Wizard
  // --------------------------------------------------------------------

  const wizardPropertyListing = document.querySelector('#wizard-property-listing');
  if (typeof wizardPropertyListing !== undefined && wizardPropertyListing !== null) {
    // Wizard form
    const wizardPropertyListingForm = wizardPropertyListing.querySelector('#wizard-property-listing-form');
    // Wizard steps
      const wizardPropertyListingFormStep1 = wizardPropertyListingForm.querySelector('#main-data');
    const wizardPropertyListingFormStep2 = wizardPropertyListingForm.querySelector('#units');
    const wizardPropertyListingFormStep3 = wizardPropertyListingForm.querySelector('#lot');
    const wizardPropertyListingFormStep4 = wizardPropertyListingForm.querySelector('#counts');
    const wizardPropertyListingFormStep5 = wizardPropertyListingForm.querySelector('#standard');
    const wizardPropertyListingFormStep6 = wizardPropertyListingForm.querySelector('#store');
    // Wizard next prev button
    const wizardPropertyListingNext = [].slice.call(wizardPropertyListingForm.querySelectorAll('.btn-next'));
    const wizardPropertyListingPrev = [].slice.call(wizardPropertyListingForm.querySelectorAll('.btn-prev'));

    const validationStepper = new Stepper(wizardPropertyListing, {
      linear: true
    });

    // البيانات الرئيسية
    const FormValidation1 = FormValidation.formValidation(wizardPropertyListingFormStep1, {
      fields: {
        // * Validate the fields here based on your requirements
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
        itemName: {
          validators: {
            notEmpty: {
              message: ' يرجى تعبئة هذا الحقل '
            }
          }
        },
        // itemNumber: {
        //   validators: {
        //     notEmpty: {
        //       message: ' يرجى تعبئة هذا الحقل '
        //     }
        //   }
        // },
        itemDiscription: {
          validators: {
            notEmpty: {
              message: ' يرجى تعبئة هذا الحقل '
            },
            stringLength: {
             min: 2,
             max: 20,
             message: 'يجب ان يكون عدد الاحرف اكثر من 2 واقل من 20'
           },
           
           regexp: {
             regexp: /^[a-zA-Zأ-ي ]+$/,
             message: 'يجب ادخال احرف  فقط'
           }
          }
        },
        itemType:{
          validators: {
            notEmpty: {
              message: ' يرجى اختيار نوع '
            }
          }
            },
            countryofOrigin: {
                validators: {
                    notEmpty: {
                        message: ' يرجى تعبئة هذا الحقل '
                    },

                    regexp: {
                        regexp: /^[a-zA-Zأ-ي ]+$/,
                        message: 'يجب ادخال احرف  فقط'
                    }
                }
            },
            BrandName:{
          validators: {
            notEmpty: {
              message: ' يرجى تعبئة هذا الحقل '
            },
           
            regexp: {
              regexp: /^[a-zA-Zأ-ي ]+$/,
              message: 'يجب ادخال احرف  فقط'
            }
          }
        },
      
        itemPrice:{
          validators: {
            notEmpty: {
              message: ' يرجى تعبئة هذا الحقل '
            },
           
            // regexp: {
            //   regexp: /^[0-9]+$/,
            //   message: 'يجب ادخال أرقام موجبة  فقط'
            // }
          }
        },
        primaryUnit:{
          validators: {
            notEmpty: {
              message: ' يرجى تعبئة هذا الحقل '
            },
           
            regexp: {
              regexp: /^[a-zA-Zأ-ي ]+$/,
              message: 'يجب ادخال احرف  فقط'
            }
          }
        },
        itemState:{
          validators: {
            notEmpty: {
                  message: '  يرجى اختيار حالة الصنف'
            }
          }
        },
        maxLimit:{
          validators: {
            notEmpty: {
              message: ' يرجى تعبئة هذا الحقل '
            },
            stringLength: {
              min: 0,
              max: 5,
             message: 'يجب ان يكون الحد الاعلى اقل من خمس خانات'
           },
           
           regexp: {
            regexp: /^[0-9]+$/,
             message: 'يجب ادخال أرقام موجبة  فقط'
           }
          }
        },
        minLimit:{
          validators: {
            notEmpty: {
              message: ' يرجى تعبئة هذا الحقل '
            },
            stringLength: {
              min: 0,
              max: 5,
             message: 'يجب ان يكون الحد الاعلى اقل من خمس خانات'
           },
           
           regexp: {
            regexp: /^[0-9]+$/,
             message: 'يجب ادخال أرقام موجبة  فقط'
           }
          }
        },
        demandlLimit:{
          validators: {
            notEmpty: {
              message: ' يرجى تعبئة هذا الحقل '
            },
            stringLength: {
              min: 0,
              max: 5,
             message: 'يجب ان يكون الحد الاعلى اقل من خمس خانات'
           },
           
           regexp: {
            regexp: /^[0-9]+$/,
             message: 'يجب ادخال أرقام موجبة  فقط'
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
          rowSelector: '.col-sm-4'
          
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

    // وحدات القياس
    const FormValidation2 = FormValidation.formValidation(wizardPropertyListingFormStep2, {
      fields: {
        // * Validate the fields here based on your requirements

      },
      plugins: {
        trigger: new FormValidation.plugins.Trigger(),
        bootstrap5: new FormValidation.plugins.Bootstrap5({
          // Use this for enabling/changing valid/invalid class
          // eleInvalidClass: '',
          eleValidClass: '',
          rowSelector: '.col-sm-4'
        }),
        autoFocus: new FormValidation.plugins.AutoFocus(),
        submitButton: new FormValidation.plugins.SubmitButton()
      }
    }).on('core.form.valid', function () {
      // Jump to the next step when all fields in the current step are valid
      validationStepper.next();
    });

    
    // Property Features
    const FormValidation3 = FormValidation.formValidation(wizardPropertyListingFormStep3, {
      fields: {
        // * Validate the fields here based on your requirements
        control:{
          validators: {
            notEmpty: {
              message: ' يرجى تعبئة هذا الحقل '
            },
            stringLength: {
              min: 0,
              max: 6,
             message: 'يجب ان يكون الحد الاعلى اقل من ستة خانات'
           },
           
           regexp: {
            regexp: /^[0-9]+$/,
             message: 'يجب ادخال أرقام موجبة  فقط'
           }
          }
        },
        dateItem:{
          validators: {
            notEmpty: {
              message: ' يرجى تعبئة هذا الحقل '
            }
          }
        },
        dateEndItem:{
          validators: {
            notEmpty: {
              message: ' يرجى تعبئة هذا الحقل '
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
          rowSelector: '.col-sm-4'
        }),
        autoFocus: new FormValidation.plugins.AutoFocus(),
        submitButton: new FormValidation.plugins.SubmitButton()
      }
    }).on('core.form.valid', function () {
      validationStepper.next();
    });

    // حسابات الصنف
    const FormValidation4 = FormValidation.formValidation(wizardPropertyListingFormStep4, {
      fields: {
        // * Validate the fields here based on your requirements

        CN:{
          validators: {
            notEmpty: {
              message: ' يرجى تعبئة هذا الحقل '
            }
          }
        },
        CNPurchase:{
          validators: {
            notEmpty: {
              message: ' يرجى تعبئة هذا الحقل '
            }
          }
        },
        CNSale:{
          validators: {
            notEmpty: {
              message: ' يرجى تعبئة هذا الحقل '
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
          rowSelector: '.col-sm-6'
        }),
        autoFocus: new FormValidation.plugins.AutoFocus(),
        submitButton: new FormValidation.plugins.SubmitButton()
      }
    }).on('core.form.valid', function () {
      // Jump to the next step when all fields in the current step are valid
      validationStepper.next();
    });

    const FormValidation5 = FormValidation.formValidation(wizardPropertyListingFormStep5, {
      fields: {
        // * Validate the fields here based on your requirements
        weight:{
          validators: {
            notEmpty: {
              message: ' يرجى تعبئة هذا الحقل '
            },
           
            regexp: {
              regexp: /^[0-9]+$/,
              message: 'يجب ادخال أرقام موجبة  فقط'
            }
          }
        },
        weightUnit:{
          validators: {
            notEmpty: {
              message: ' يرجى تعبئة هذا الحقل '
            },
           
            regexp: {
              regexp: /^[a-zA-Zأ-ي ]+$/,
              message: 'يجب ادخال احرف  فقط'
            }
          }
        },
        size:{
          validators: {
            notEmpty: {
              message: ' يرجى تعبئة هذا الحقل '
            },
           
            regexp: {
              regexp: /^[0-9]+$/,
              message: 'يجب ادخال أرقام موجبة  فقط'
            }
          }
        },
        sizeUnit:{
          validators: {
            notEmpty: {
              message: ' يرجى تعبئة هذا الحقل '
            },
           
            regexp: {
              regexp: /^[a-zA-Zأ-ي ]+$/,
              message: 'يجب ادخال احرف  فقط'
            }
          }
        },
        dimensionalUnit:{
          validators: {
            notEmpty: {
              message: ' يرجى تعبئة هذا الحقل '
            },
           
            regexp: {
              regexp: /^[a-zA-Zأ-ي ]+$/,
              message: 'يجب ادخال احرف  فقط'
            }
          }
        },
        length1:{
          validators: {
            notEmpty: {
              message: ' يرجى تعبئة هذا الحقل '
            },
           
            regexp: {
              regexp: /^[0-9]+$/,
              message: 'يجب ادخال أرقام موجبة  فقط'
            }
          }
        },
        width1:{
          validators: {
            notEmpty: {
              message: ' يرجى تعبئة هذا الحقل '
            },
           
            regexp: {
              regexp: /^[0-9]+$/,
              message: 'يجب ادخال أرقام موجبة  فقط'
            }
          }
        },
        height1:{
          validators: {
            notEmpty: {
              message: ' يرجى تعبئة هذا الحقل '
            },
           
            regexp: {
              regexp: /^[0-9]+$/,
              message: 'يجب ادخال أرقام موجبة  فقط'
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
          rowSelector: '.col-sm-6'
        }),
        autoFocus: new FormValidation.plugins.AutoFocus(),
        submitButton: new FormValidation.plugins.SubmitButton()
      }
    }).on('core.form.valid', function () {
      // Jump to the next step when all fields in the current step are valid
      validationStepper.next();
    });
    // Price Details
    const FormValidation6 = FormValidation.formValidation(wizardPropertyListingFormStep6, {
     fields: {
        // * Validate the fields here based on your requirements
        
      },
      plugins: {
        trigger: new FormValidation.plugins.Trigger(),
        bootstrap5: new FormValidation.plugins.Bootstrap5({
          // Use this for enabling/changing valid/invalid class
          // eleInvalidClass: '',
          eleValidClass: '',
          rowSelector: '.col-sm-4'
        }),
        autoFocus: new FormValidation.plugins.AutoFocus(),
        submitButton: new FormValidation.plugins.SubmitButton()
      }
    }).on('core.form.valid', function () {
      // You can submit the form
      // wizardPropertyListingForm.submit()
      // or send the form data to server via an Ajax request
      // To make the demo simple, I just placed an alert
      // alert('Submitted..!!');
    });

    wizardPropertyListingNext.forEach(item => {
      item.addEventListener('click', event => {
        // When click the Next button, we will validate the current step
        switch (validationStepper._currentIndex) {
          case 0:
            FormValidation1.validate();
            break;

          case 1:
            FormValidation2.validate();
            break;

          case 2:
            FormValidation3.validate();
            break;

          case 3:
            FormValidation4.validate();
            break;

            case 4:
              FormValidation5.validate();
              break;

          case 5:
            FormValidation6.validate();
            break;

          default:
            break;
        }
      });
    });

    wizardPropertyListingPrev.forEach(item => {
      item.addEventListener('click', event => {
        switch (validationStepper._currentIndex) {
          case 5:
            validationStepper.previous();
            break;

            case 4:
              validationStepper.previous();
              break;

          case 3:
            validationStepper.previous();
            break;

          case 2:
            validationStepper.previous();
            break;

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
