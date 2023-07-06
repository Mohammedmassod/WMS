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
        const wizardValidationFormStep1 = wizardValidationForm.querySelector('#License-applicant-data');
        const wizardValidationFormStep2 = wizardValidationForm.querySelector('#Shop-data-Recharge');
        const wizardValidationFormStep3 = wizardValidationForm.querySelector('#Refill-store-opening');
        const wizardValidationFormStep4 = wizardValidationForm.querySelector('#Item-Storge');
        const wizardValidationFormStep5 = wizardValidationForm.querySelector('#Commercial-record');
        const wizardValidationFormStep6 = wizardValidationForm.querySelector('#Tax-Number');
        const wizardValidationFormStep7 = wizardValidationForm.querySelector('#Store-owner-Data');
        const wizardValidationFormStep8 = wizardValidationForm.querySelector('#Attached-Document');
        // Wizard next prev button
        const wizardValidationNext = [].slice.call(wizardValidationForm.querySelectorAll('.btn-next'));
        const wizardValidationPrev = [].slice.call(wizardValidationForm.querySelectorAll('.btn-prev'));

        const validationStepper = new Stepper(wizardValidation, {
            linear: true
        });

        // Account details
        const FormValidation1 = FormValidation.formValidation(wizardValidationFormStep1, {
            fields: {
                formValidationFirstName: {
                    validators: {
                        notEmpty: {
                            message: 'يرجى تعبئة  اسم طالب الترخيص الاول '
                        }
                    }
                },
                formValidationLastName: {
                    validators: {
                        notEmpty: {
                            message: 'يرجى تعبئة  اسم العائلة '

                        }
                    }
                },
                formValidationCardtype: {
                    validators: {
                        notEmpty: {
                            message: ' يرجى اختيار نوع البطاقة '

                        }
                    }
                },
                formValidationCardtNumber: {
                    validators: {
                        notEmpty: {
                            message: 'يرجى تعبئة رقم البطاقة '
                        },
                        stringLength: {
                            min: 0,
                            max: 11,
                            message: 'يجب ان يكون رقم البطاقة مكون من  11 رقم'
                        },

                        regexp: {
                            regexp: /^[0-9]+$/,
                            message: 'يجب ادخال أرقام موجبة  فقط'
                        }
                    }
                },
                formValidationDob: {
                    validators: {
                        notEmpty: {
                            message: 'يرجى اختيار تاريخ الاصدار '
                        },
                   
                    }
                },
                formValidationPlaceRelease: {
                    validators: {
                        notEmpty: {
                            message: ' يرجى تعبئة مكان صدورها '

                        }
                    }
                },
                formValidationNationality: {
                    validators: {
                        notEmpty: {
                            message: ' يرجى تعبئة الجنسية  '

                        }
                    }
                },
                formValidationNumberphon: {
                    validators: {
                        notEmpty: {
                            message: 'يرجى تعبئة رقم الهاتف '
                        }
                    }
                },
                formValidationphone: {
                    validators: {
                        notEmpty: {
                            message: 'يرجى تعبئة رقم الجوال '
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

        // Personal info
        const FormValidation2 = FormValidation.formValidation(wizardValidationFormStep2, {
            fields: {
                formValidationProvince: {
                    validators: {
                        notEmpty: {
                            message: 'يرجى تعبئة عنوان المحافظة '
                        }
                    }
                },
                formValidationDirectorate: {
                    validators: {
                        notEmpty: {
                            message: 'يرجى تعبئة عنوان المديرية '
                        }
                    }
                },
                formValidationFront: {
                    validators: {
                        notEmpty: {
                            message: 'يرجى تعبئة  أمام '
                        }
                    }
                },
                formValidationStreet: {
                    validators: {
                        notEmpty: {
                            message: 'يرجى تعبئة  عنوان الشارع  '
                        }
                    }
                },
                formValidationNeighbohood: {
                    validators: {
                        notEmpty: {
                            message: 'يرجى تعبئة جوار  '
                        }
                    }
                },
                formValidationTypebuilding: {
                    validators: {
                        notEmpty: {
                            message: 'يرجى اختيار نوع المخزن'
                        }
                    }
                },
                StoreMode: {
                    validators: {
                        notEmpty: {
                            message: 'يرجى اختيار وضع مخزن إعادة التعبئة'
                        }
                    }
                },
                StockStatusformValidationStoreMode: {
                    validators: {
                        notEmpty: {
                            message: 'يرجى اختيار حالة محل إعادة التعبئة'
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

        // Bootstrap Select (i.e Language select)
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
                        placeholder: 'يرجى اختيار نوع المخزن',
                        dropdownParent: $this.parent()
                    })
                    .on('change.select2', function () {
                        // Revalidate the color field when an option is chosen
                        FormValidation2.revalidateField('formValidationTypebuilding');
                    });
            });
      }  
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

        // Social links
        const FormValidation3 = FormValidation.formValidation(wizardValidationFormStep3, {
            fields: {
                formValidationNameStore: {
                    validators: {
                        notEmpty: {
                            message: 'يرجى تعبئة اسم المحل '
                        }
                    }
                },
              
               formValidationLength: {
                validators: {
                    notEmpty: {
                        message: ' يرجى تعبئة طول المخزن  '

                    }
                }
            },
            formValidationWidth: {
                validators: {
                    notEmpty: {
                        message: ' يرجى تعبئة عرض المخزن  '

                    }
                }
            },
            formValidationHeight: {
                validators: {
                    notEmpty: {
                        message: ' يرجى تعبئة ارتفاع المخزن  '

                    }
                }
            },
            formValidationNumberSlots: {
                validators: {
                    notEmpty: {
                        message: ' يرجى تعبئة عدد الفتحات   '

                    }
                }
            },
            EstimatedCapacity: {
                validators: {
                    notEmpty: {
                        message: ' يرجى تعبئة السعة التقديرية   '

                    }
                }
            },
            StorageConditions: {
                validators: {
                    notEmpty: {
                        message: ' يرجى اختيار  ظروف التخزين   '

                    }
                }

            },
            DateRequest: {
                validators: {
                    notEmpty: {
                        message: 'يرجى اختيار تاريخ الطلب '
                    }
                  
                }
            },
            StatusOpen: {
                validators: {
                    notEmpty: {
                        message: '   يرجى اختيار حالة فتح مخزن إعادة التعبئة   '

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
                //  itmeName: {
                //    validators: {
                //        notEmpty: {
                //            message: 'يرجى اختيار اسم السلعة '
                //        }
                //    }
                //},
                //BrandName: {
                //    validators: {
                //        notEmpty: {
                //            message: 'يرجى تعبئة اسم الماركة    '
                //        }
                //    }
                //},

                //CountryOrigin: {
                //    validators: {
                //        notEmpty: {
                //            message: ' يرجى اختيار بلد المنشأ   '

                //        }
                //    }
                //},
                //ItemSize: {
                //    validators: {
                //        notEmpty: {
                //            message: ' يرجى تعبئة وزن السلعة المراد  تعبئته '

                //        }
                //    }
                //},
                //ItmeWeight: {
                //    validators: {
                //        notEmpty: {
                //            message: ' يرجى تعبئة حجم السلعة  المراد  تعبئته   '

                //        }
                //    }
                //},

                //ProductionDate: {
                //    validators: {
                //        notEmpty: {
                //            message: 'يرجى اختيار تاريخ الطلب '
                //        },
                //        date: {
                //            format: 'YYYY/MM/DD',
                //            message: 'البيانات ليس من نوع تاريخ'
                //        }
                //    }
                //},
                //EndDate: {
                //    validators: {
                //        notEmpty: {
                //            message: 'يرجى اختيار تاريخ الطلب '
                //        },
                //        date: {
                //            format: 'YYYY/MM/DD',
                //            message: 'البيانات ليس من نوع تاريخ'
                //        }
                //    }
                //},
                //ItmeStatus: {
                //    validators: {
                //        notEmpty: {
                //            message: '  يرجى اختيار حالة السلعة  '

                //        }
                //    }

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
            }
        }).on('core.form.valid', function () {
            // Jump to the next step when all fields in the current step are valid
            validationStepper.next();
        });
        // السجل التجاري
        const FormValidation5 = FormValidation.formValidation(wizardValidationFormStep5, {
            fields: {
                Names: {
                    validators: {
                        notEmpty: {
                            message: 'يرجى تعبئة اسم مالك السجل '
                        }
                    }
                },
              

                CRN: {
                    validators: {
                        notEmpty: {
                            message: ' يرجى تعبئة رقم السجل التجاري   '

                        }
                    }
                },
                Category: {
                    validators: {
                        notEmpty: {
                            message: 'يرجى اختيار نوع الفئة '
                        }
                    }
                },
                placeActivity: {
                    validators: {
                        notEmpty: {
                            message: ' يرجى تعبئة مكان النشاط  '

                        }
                    }
                },
                TradeName: {
                    validators: {
                        notEmpty: {
                            message: ' يرجى تعبئة الاسم التجاري  '

                        }
                    }
                },
             
            
                IssueDate: {
                    validators: {
                        notEmpty: {
                            message: 'يرجى اختيار تاريخ الإصدار '
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
      // الرقم الضريبي
        const FormValidation6 = FormValidation.formValidation(wizardValidationFormStep6, {
            fields: {
                TIN: {
                    validators: {
                        notEmpty: {
                            message: 'يرجى تعبئة رقم الضريبي '
                        }
                    }
                },
                DateEndRenewal: {
                    validators: {
                        notEmpty: {
                            message: 'يرجى اختيار تاريخ اخر تجديد '
                        }
                       
                    }
                },
                PlaceEmission: {
                validators: {
                    notEmpty: {
                        message: ' يرجى تعبئة   جهة الإصدار  '

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
            // مالك المخزن
        const FormValidation7 = FormValidation.formValidation(wizardValidationFormStep7, {
            fields: {
                StoreOwnerName: {
                    validators: {
                        notEmpty: {
                            message: 'يرجى تعبئة اسم مالك  '
                        }
                    }
                },
                OwnerNameLast: {
                    validators: {
                        notEmpty: {
                            message: 'يرجى تعبئة اسم العائلة  '
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
            // الوثائق المرفقة
        const FormValidation8 = FormValidation.formValidation(wizardValidationFormStep8, {
            fields: {
                TypeDocument: {
                    validators: {
                        notEmpty: {
                            message: 'يرجى تعبئة نوع الوثيقة '
                        }
                    }
                },
                formFile: {
                    validators: {
                        notEmpty: {
                            message: 'يرجى اختيار  صورة الوثيقة '
                        }
                    }
                },

                discription: {
                validators: {
                    notEmpty: {
                        message: ' يرجى تعبئة وصف الوثيقة  '

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
            // You can submit the form
            // wizardValidationForm.submit()
            // or send the form data to server via an Ajax request
            // To make the demo simple, I just placed an alert
            alert('Submitted..!!');
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
                           
                    case 5:
                        FormValidation6.validate();
                        break;
                          
                    case 6:
                        FormValidation7.validate();
                        break;
                       
                    case 7:
                        FormValidation8.validate();
                        break;

                    default:
                        break;
                }
            });
        });

        wizardValidationPrev.forEach(item => {
            item.addEventListener('click', event => {
                switch (validationStepper._currentIndex) {
                    case 7:
                        validationStepper.previous();
                     
                        break;

                      case 6:
                        validationStepper.previous();
                        break;

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
