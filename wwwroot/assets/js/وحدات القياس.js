/**
 * add unit
 */
'use strict';

(function () {

  const addNewUserForm = document.getElementById('offcanvasAddunitV');

 const add = FormValidation.formValidation(addNewUserForm, {
   fields: {
    itemName: {
       validators: {
         notEmpty: {
           message: 'يرجى تعبئة هذا الحقل '
         }
       }
     },
     itemDisc: {
        validators: {
          notEmpty: {
            message: 'يرجى تعبئة هذا الحقل '
          },
           
          regexp: {
            regexp: /^[a-zA-Zأ-ي ]+$/,
            message: 'يجب ادخال احرف  فقط'
          }
        }
      },
     mainUnit: {
        validators: {
          notEmpty: {
            message: 'يرجى تعبئة هذا الحقل '
          },
           
          regexp: {
            regexp: /^[a-zA-Zأ-ي ]+$/,
            message: 'يجب ادخال احرف  فقط'
          }
        }
      },
     secondUnit: {
        validators: {
          notEmpty: {
            message: 'يرجى تعبئة هذا الحقل '
          },
           
          regexp: {
            regexp: /^[a-zA-Zأ-ي ]+$/,
            message: 'يجب ادخال احرف  فقط'
          }
        }
      },
     full: {
      validators: {
         notEmpty: {
          message: 'يرجى تعبئة هذا الحقل '
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
       eleValidClass: '',
       rowSelector: function (field, ele) {
         // field is the field name & ele is the field element
         return '.mb-3';
       }
     }),
     submitButton: new FormValidation.plugins.SubmitButton(),
     // Submit the form when all fields are valid
     // defaultSubmit: new FormValidation.plugins.DefaultSubmit(),
     autoFocus: new FormValidation.plugins.AutoFocus()
   }
 });
})();