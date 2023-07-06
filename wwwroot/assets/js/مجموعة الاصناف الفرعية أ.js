/**
 *add AItemGroupN Script
 */
 'use strict';

 (function () { 
  const select2 = $('.select2'),
        addNewUserForm = document.getElementById('AItemGroupN');
   
  const add = FormValidation.formValidation(addNewUserForm, {
    fields: {
        ItemCod: {
        validators: {
          notEmpty: {
            message: 'يرجى ادخال كود المجموعة '
          }
        }
      },

      AItemGroup: {
       validators: {
          notEmpty: {
           message: 'يرجى ادخال إسم المجموعة '
           },
           stringLength: {
             min: 1,
             max:50,
             message: '   يجب ان يكون حجم المدخلات أقل من 51 حرف  '
           }
         }
      },

      primaryItemGroup: {
        validators: {
          notEmpty: {
            message: 'يرجى إختيار المجموعة الرئيسية '
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
  
   // select2
   if (select2.length) {
    select2.each(function () {
      var $this = $(this);
      $this.wrap('<div class="position-relative"></div>');
      $this.select2({
       // placeholder: 'يرجى الإختيار',
        dropdownParent: $this.parent()
      });
    });
  }
})();