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
        const wizardValidationFormStep1 = wizardValidationForm.querySelector('#main-data');
        const wizardValidationFormStep2 = wizardValidationForm.querySelector('#units');
        const wizardValidationFormStep3 = wizardValidationForm.querySelector('#counts');
        const wizardValidationFormStep4 = wizardValidationForm.querySelector('#standard');
        const wizardValidationFormStep5 = wizardValidationForm.querySelector('#StorageConditions');
     
        // Wizard next prev button
        const wizardValidationNext = [].slice.call(wizardValidationForm.querySelectorAll('.btn-next'));
        const wizardValidationPrev = [].slice.call(wizardValidationForm.querySelectorAll('.btn-prev'));

        const validationStepper = new Stepper(wizardValidation, {
            linear: true
        });

        // Account details
        const FormValidation1 = FormValidation.formValidation(wizardValidationFormStep1, {
            fields: {
                // * Validate the fields here based on your requirements
                //itemGroupA: {
                //    validators: {
                //        notEmpty: {
                //            message: ' يرجى اختيار مجموعة '
                //        }
                //    }
                //},
                //itemGroupB: {
                //    validators: {
                //        notEmpty: {
                //            message: ' يرجى اختيار مجموعة '
                //        }
                //    }
                //},
                //itemGroupC: {
                //    validators: {
                //        notEmpty: {
                //            message: ' يرجى اختيار مجموعة '
                //        }
                //    }
                //},
                itemName: {
                    validators: {
                        notEmpty: {
                            message: ' يرجى تعبئة اسم الصنف '
                        }
                    }
                },
                itemDiscription: {
                    validators: {
                        notEmpty: {
                            message: ' يرجى تعبئة  وصف الصنف '
                        },
                        stringLength: {
                            min: 3,
                            max: 10,
                            message: 'يجب ان يكون عدد الاحرف اكثر من 3 واقل من 10'
                        },

                        regexp: {
                            regexp: /^[a-zA-Zأ-ي ]+$/,
                            message: 'يجب ادخال احرف  فقط'
                        }
                    }
                },
                //itemType: {
                //    validators: {
                //        notEmpty: {
                //            message: '  يرجى اختيار نوع الصنف '
                //        }
                //    }
                //},
                itemPrice: {
                    validators: {
                        notEmpty: {
                            message: ' يرجى تعبئة السعر  '
                        }
                    }
                },
                primaryUnit: {
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
                //ProductionDate: {
                //    validators: {
                //        notEmpty: {
                //            message: 'يرجى اختيار تاريخ انتاج الصنف '
                //        },
                //        date: {
                //            format: 'يوم/شهر/سنة',
                //            message: 'البيانات ليس من نوع تاريخ'
                //        }
                //    }
                //},
                //EndDate: {
                //    validators: {
                //        notEmpty: {
                //            message: 'يرجى اختيار تاريخ انتهاء الصنف '
                //        },
                //        date: {
                //            format: 'يوم/شهر/سنة',
                //            message: 'البيانات ليس من نوع تاريخ'
                //        }
                //    }
                //},
                ItmeStatus: {
                    validators: {
                        notEmpty: {
                            message: '   يرجى اختيار حالة السلعة    '

                        }
                    }

                }
            },
                //barcode: {
                //    validators: {
                //        notEmpty: {
                //            message: ' يرجى تعبئة البركود  '
                //        }
                //    }
                //}

      
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
        const FormValidation2 = FormValidation.formValidation(wizardValidationFormStep2, {
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

      
         // select3
      //  if (select3.length) {
      //      select3.each(function () {
      //          var $this = $(this);
      //          $this.wrap('<div class="position-relative"></div>');
      //          $this
      //              .select3({
      //                  placeholder: 'يرجى اختيار نوع المخزن',
      //                  dropdownParent: $this.parent()
      //              })
      //              .on('change.select3', function () {
      //                  // Revalidate the color field when an option is chosen
      //                  FormValidation2.revalidateField('StoreMode');
      //              });
      //      });
      //}   // select4
      //  if (select4.length) {
      //      select4.each(function () {
      //          var $this = $(this);
      //          $this.wrap('<div class="position-relative"></div>');
      //          $this
      //              .select4({
      //                  placeholder: 'يرجى اختيار نوع المخزن',
      //                  dropdownParent: $this.parent()
      //              })
      //              .on('change.select4', function () {
      //                  // Revalidate the color field when an option is chosen
      //                  FormValidation2.revalidateField('StockStatus');
      //              });
      //      });
      //}  

        // الشركة المنتجة
        const FormValidation3 = FormValidation.formValidation(wizardValidationFormStep3, {
            fields: {
               
              
                CountryOrigin: {
                    validators: {
                        notEmpty: {
                            message: ' يرجى اختيار بلد المنشأ   '

                        }
                    }
                },
                BrandName: {
                    validators: {
                        notEmpty: {
                            message: 'يرجى تعبئة اسم الماركة    '
                        }
                    }
                },

                ItemSize: {
                    validators: {
                        notEmpty: {
                            message: ' يرجى تعبئة وزن السلعة  '

                        }
                    }
                },
                ItmeWeight: {
                    validators: {
                        notEmpty: {
                            message: ' يرجى تعبئة حجم السلعة     '

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
            // Jump to the next step when all fields in the current step are valid
            validationStepper.next();
        });
        const FormValidation4 = FormValidation.formValidation(wizardValidationFormStep4, {
     
            fields: {
                // * Validate the fields here based on your requirements
                weight: {
                    validators: {
                        notEmpty: {
                            message: ' يرجى تعبئة وزن الصنف '
                        },

                        regexp: {
                            regexp: /^[0-9]+$/,
                            message: 'يجب ادخال أرقام موجبة  فقط'
                        }
                    }
                },
                weightUnit: {
                    validators: {
                        notEmpty: {
                            message: ' يرجى تعبئة وحدة القياس '
                        },

                        regexp: {
                            regexp: /^[a-zA-Zأ-ي ]+$/,
                            message: 'يجب ادخال احرف  فقط'
                        }
                    }
                },
                size: {
                    validators: {
                        notEmpty: {
                            message: ' يرجى تعبئة الحجم الصنف '
                        },

                        regexp: {
                            regexp: /^[0-9]+$/,
                            message: 'يجب ادخال أرقام موجبة  فقط'
                        }
                    }
                },
                sizeUnit: {
                    validators: {
                        notEmpty: {
                            message: ' يرجى تعبئة وحدة القياس '
                        },

                        regexp: {
                            regexp: /^[a-zA-Zأ-ي ]+$/,
                            message: 'يجب ادخال احرف  فقط'
                        }
                    }
                },
                dimensionalUnit: {
                    validators: {
                        notEmpty: {
                            message: ' يرجى تعبئة وحدة قياس الأبعاد   '
                        },

                        regexp: {
                            regexp: /^[a-zA-Zأ-ي ]+$/,
                            message: 'يجب ادخال احرف  فقط'
                        }
                    }
                },
                length1: {
                    validators: {
                        notEmpty: {
                            message: ' يرجى تعبئة الطول '
                        },

                        regexp: {
                            regexp: /^[0-9]+$/,
                            message: 'يجب ادخال أرقام موجبة  فقط'
                        }
                    }
                },
                width1: {
                    validators: {
                        notEmpty: {
                            message: ' يرجى تعبئة العرض '
                        },

                        regexp: {
                            regexp: /^[0-9]+$/,
                            message: 'يجب ادخال أرقام موجبة  فقط'
                        }
                    }
                },
                height1: {
                    validators: {
                        notEmpty: {
                            message: ' يرجى تعبئة الارتفاع '
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
        // شروط التخزين
        const FormValidation5 = FormValidation.formValidation(wizardValidationFormStep5, {
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

                    case 3:
                        FormValidation4.validate();
                        break;

                    case 4:
                        FormValidation5.validate();
                        break;
                
                    default:
                        break;
                }
            });
        });

        wizardValidationPrev.forEach(item => {
            item.addEventListener('click', event => {
                switch (validationStepper._currentIndex) {
                   
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
