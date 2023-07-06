/**
 *  Form Wizard
 */

'use strict';

(function () {
    const select2 = $('.select2'),
        //select3 = $('.select3'),
        //select4 = $('.select4'),
        selectPicker = $('.selectpicker');
  // Wizard Validation
  // --------------------------------------------------------------------
  const wizardValidation = document.querySelector('#wizard-validation');
  if (typeof wizardValidation !== undefined && wizardValidation !== null) {
    // Wizard form
      const wizardValidationForm = wizardValidation.querySelector('#wizard-validation-form');
    // Wizard steps
      const wizardValidationFormStep1 = wizardValidationForm.querySelector('#Examination-inspection');
      const wizardValidationFormStep2 = wizardValidationForm.querySelector('#Storage-Specifications');
      const wizardValidationFormStep3 = wizardValidationForm.querySelector('#Refrigerators-Checkn');
    // Wizard next prev button
    const wizardValidationNext = [].slice.call(wizardValidationForm.querySelectorAll('.btn-next'));
    const wizardValidationPrev = [].slice.call(wizardValidationForm.querySelectorAll('.btn-prev'));

    const validationStepper = new Stepper(wizardValidation, {
      linear: true
    });

    // Account details
    const FormValidation1 = FormValidation.formValidation(wizardValidationFormStep1, {
      fields: {
        //    formValidationFirstName: {
        //        validators: {
        //            notEmpty: {
        //                message: '���� �����  ��� ������ ����� '
        //            }
        //        }
        //    },
        //    formValidationLastName: {
        //        validators: {
        //            notEmpty: {
        //                message: '���� �����  ��� ������� '

        //            }
        //        }
        //    },
      
        //    formValidationProvince: {
        //        validators: {
        //            notEmpty: {
        //                message: '���� ����� ����� �������� '
        //            }
        //        }
        //    },
        //    formValidationDirectorate: {
        //        validators: {
        //            notEmpty: {
        //                message: '���� ����� ����� �������� '
        //            }
        //        }
        //    },
        //    formValidationFront: {
        //        validators: {
        //            notEmpty: {
        //                message: '���� �����  ���� '
        //            }
        //        }
        //    },
        //    formValidationStreet: {
        //        validators: {
        //            notEmpty: {
        //                message: '���� �����  ����� ������  '
        //            }
        //        }
        //    },
        //    formValidationNeighbohood: {
        //        validators: {
        //            notEmpty: {
        //                message: '���� ����� ����  '
        //            }
        //        }
        //    },
        //    StoreCategory: {
        //        validators: {
        //            notEmpty: {
        //                message: '  ���� ������ ��� ������  '
        //            }
        //        }
        //    },
        //    ExaminationDate: {
        //        validators: {
        //            notEmpty: {
        //                message: '���� ������ ����� ���� �����  '
        //            },
        //            date: {
        //                format: 'YYYY/MM/DD',
        //                message: '�������� ��� �� ��� �����'
        //            }
        //        }
   
        //}
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

    // Personal info
    const FormValidation2 = FormValidation.formValidation(wizardValidationFormStep2, {
      fields: {

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

      if (selectPicker.length) {
          selectPicker.each(function () {
              var $this = $(this);
              $this.selectpicker().on('change', function () {
                  FormValidation2.revalidateField('formValidationLanguage');
              });
          });
      }

      // select2
      if (select2.length) {
          select2.each(function () {
              var $this = $(this);
              $this.wrap('<div class="position-relative"></div>');
              $this
                  .select2({
                      placeholder: '���� ������ ��� ������',
                      dropdownParent: $this.parent()
                  })
                  .on('change.select2', function () {
                      // Revalidate the color field when an option is chosen
                      FormValidation2.revalidateField('formValidationTypebuilding');
                  });
          });
      }
    // Social links
    const FormValidation3 = FormValidation.formValidation(wizardValidationFormStep3, {
   
        fields: {
                       'cooling-temp' : {
                        validators: {
                            notEmpty: {
                                message: '���� ������ ������ �� ��� ������ ����� ����� ���� ����� �������.'
                            }
                        }
                    },
                    'freezing-temp' : {
                        validators : {
                            notEmpty: {
                                message: '���� ������ ������ �� ��� ������ ����� ����� ���� ����� �������.'
                            }
                        }
                    },
                    'damaged-items': {
                        validators: {
                            notEmpty: {
                                message: '���� ������ ���� �� �� ���� ���� ���� ���� ����� �� ����� �� ��� ����� ���� �������.'
                            }
                        }
                    },
                    'fridge-efficiency': {
                        validators: {
                            notEmpty: {
                                message: '���� ������ ����� ��� ��������.'
                            }
                        }
                    },
                   'storage-arrangement': {
                        validators: {
                            notEmpty: {
                                message: '���� ������ ����� ������ ������� ��������.'
                            }
                        }
                    },
                    'temperature-measurement': {
                        validators: {
                            notEmpty: {
                                message: '���� ������ ���� ����� ���� ���� �������.'
                            }
                        }
                    },
                   ' fridge-loading': {
                        validators: {
                            notEmpty: {
                                message: '���� ������ ����� �������.'
                            }
                        }
                    },
                    'status': {
                        validators: {
                            notEmpty: {
                                message: '���� ������ ������.'
                            }
                        }
                    },
       ' specialist-name': {
                        validators: {
                            notEmpty: {
                                message: '���� ����� ��� ������.'
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
        // You can submit the form
        // wizardPropertyListingForm.submit()
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

          case 2:
            FormValidation3.validate();
            break;

          default:
            break;
        }
      });
    });

    wizardValidationPrev.forEach(item => {
      item.addEventListener('click', event => {
        switch (validationStepper._currentIndex) {
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
