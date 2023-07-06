/**
 * Account Settings - Security
 */

'use strict';

document.addEventListener('DOMContentLoaded', function (e) {
  (function () {
    const formChangePass = document.querySelector('#formAccountSettings');
     

    // Form validation for Change password
    if (formChangePass) {
      const fv = FormValidation.formValidation(formChangePass, {
        fields: {
          currentPassword: {
            validators: {
              notEmpty: {
                message: 'يرجى إدخال كلمة المرور الحالية'
              },
              stringLength: {
                min: 8,
                message: 'يجب أن تكون أكثر من 8 '
              }
            }
          },
          newPassword: {
            validators: {
              notEmpty: {
                message: 'يرجى إدخال كلمة المرور الجديدة'
              },
              stringLength: {
                min: 8,
                message: 'يجب أن تكون أكثر من 8 '
              }
            }
          },
          confirmPassword: {
            validators: {
              notEmpty: {
                message: 'يرجى تأكيد كلمة المرور'
              },
              identical: {
                compare: function () {
                  return formChangePass.querySelector('[name="newPassword"]').value;
                },
                message: 'كلمة المرور وتأكيدها غير متطابقة'
              },
              stringLength: {
                min: 8,
                message: 'يجب أن تكون أكثر من 8 '
              }
            }
          }
        },
        plugins: {
          trigger: new FormValidation.plugins.Trigger(),
          bootstrap5: new FormValidation.plugins.Bootstrap5({
            eleValidClass: '',
            rowSelector: '.col-md-6'
          }),
          submitButton: new FormValidation.plugins.SubmitButton(),
          // Submit the form when all fields are valid
          // defaultSubmit: new FormValidation.plugins.DefaultSubmit(),
          autoFocus: new FormValidation.plugins.AutoFocus()
        },
        init: instance => {
          instance.on('plugins.message.placed', function (e) {
            if (e.element.parentElement.classList.contains('input-group')) {
              e.element.parentElement.insertAdjacentElement('afterend', e.messageElement);
            }
          });
        }
      });
    }

    
  })();
});

// Select2 (jquery)
$(function () {
  var select2 = $('.select2');

  // Select2 API Key
  if (select2.length) {
    select2.each(function () {
      var $this = $(this);
      $this.wrap('<div class="position-relative"></div>');
      $this.select2({
        dropdownParent: $this.parent()
      });
    });
  }
});
