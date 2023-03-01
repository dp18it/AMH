(function ($) {
    "use strict";
    var topfarms = {};

    /*************************
      Predefined Variables
    *************************/

    var $window = $(window),
        $document = $(document)


    // Check if function exists
    $.fn.exists = function () {
        return this.length > 0;
    };

    // topfarms.aos = function () {

    //   loadScript(plugin_path + 'aos/aos.js', function () {
    //   });

    // };

    // TOGGLE PASSWORD
    //topfarms.togglePassword = function () {
    //    if ($('.js-toggle-password').exists()) {
    //        $(document).on('click', '.Oldpassword-icon', function () {
    //            $(this).toggleClass("bb-eye bb-eye-off");
    //            debugger;
    //            var input = $(".js-toggle-password");
    //            input.attr('type') === 'password' ? input.attr('type', 'text') : input.attr('type', 'password')
    //        });

    //    }
    //};

    $('#passwordCheckbox').change(function () {
        if ($(this).is(':checked')) {
            $('input[type="password"]').addClass('password-toggle');
            $('input[type="password"]').prop('type', 'text');
        } else {
            $('.password-toggle').prop('type', 'password');
        }
    });

    $(".toggle-password").click(function () {
        $(this).toggleClass("bb-eye bb-eye-off");
        var input = $($(this).attr("toggle"));
        if (input.attr("type") == "password") {
            input.attr("type", "text");
        } else {
            input.attr("type", "password");
        }
    });

    topfarms.togglePassword = function () {
        if ($('.js-toggle-password').exists()) {

            $(document).on('click', '.Newpassword-icon', function () {
                $(this).toggleClass("bb-eye bb-eye-off");
                debugger;
                var input = $(".js-toggle-password");
                input.attr('type') === 'password' ? input.attr('type', 'text') : input.attr('type', 'password')
            });
        }
    };

    // TOOLTIP
    topfarms.toggleTooltip = function () {
        if ($('[data-toggle="tooltip"]').exists()) {
            $('[data-toggle="tooltip"]').tooltip()
        }
    };

    // SELECT SERVICES
    topfarms.selectServices = function () {
        if ($('.selecet-services-group').exists()) {
            $(".selecet-services-group .card").on("click", function () {
                $(this).toggleClass("active");
            });
        }
    };

    // SWEET ALERT
    topfarms.addEmployeeSA = function () {
        if ($('#addEmployee').exists()) {
            loadScript(plugin_path + 'sweetalert/sweetalert2.min.js', function () {

                $("#addEmployee").click(function () {
                    Swal.fire({
                        position: 'top-end',
                        icon: 'success',
                        title: 'Employee Added Successfully',
                        showConfirmButton: false,
                        timer: 1200
                    })
                });
            });
        }
    };

    // BOOTSTRAP TOGGLE
    topfarms.bootstrapToggle = function () {
        if ($("[data-toggle='toggle']").exists()) {
            loadScript(plugin_path + 'bootstrap-switch/bootstrap4-toggle.min.js', function () {
                $("[data-toggle='toggle']").bootstrapToggle();
            });
        }
    };

    // SIMPLE BAR
    topfarms.simpleBar = function () {
        if ($('[data-simplebar]').exists()) {
            loadScript(plugin_path + 'simplebar/simplebar.min.js', function () { });
        }
    };

    // SVG INJECT
    topfarms.svgInject = function () {
        if ($('[data-inject]').exists()) {
            loadScript(plugin_path + 'simplebar/simplebar.min.js', function () {
                SVGInject(document.querySelectorAll("[data-inject]"));
            });
        }
    };

    // BOOTSTRAP SELECT
    topfarms.bootstrapSelect = function () {
        if ($('.selectpicker').exists()) {
            loadScript(plugin_path + 'bootstrap-select/bootstrap-select.min.js', function () {
                $('.selectpicker').selectpicker();
            });
        }
    };

    // DATE RANGE PICKER
    topfarms.dateRangePicker = function () {
        if ($('.datepicker').exists()) {
            loadScript(plugin_path + 'daterangepicker/daterangepicker.js', function () {
                $('input[name="employeeModalSinglePicker"]').daterangepicker({
                    parentEl: "#employeeModal .modal-body",
                    "singleDatePicker": true,
                    "showDropdowns": true,
                });
                $('input.singledatepicker').daterangepicker({
                    "singleDatePicker": true,
                    autoUpdateInput: false,
                    "showDropdowns": true,
                    locale: {
                        cancelLabel: 'Clear'
                    }
                });

                $('input.singledatepicker').attr("placeholder", "mm/dd/yyyy");
                $('input.singledatepicker').on('apply.daterangepicker', function (ev, picker) {
                    debugger;
                    $(this).val(picker.startDate.format('MM/DD/YYYY'));
                    $('input.singledatepicker').trigger('keyup');
                });

                $('input.singledatepicker').on('cancel.daterangepicker', function (ev, picker) {
                    $(this).val('');
                });

                $('input.previousdatepicker').daterangepicker({
                    "singleDatePicker": true,
                    "showDropdowns": true,
                    autoUpdateInput: false,
                    minDate: new Date(),
                    locale: {
                        cancelLabel: 'Clear'
                    }
                });
                $('input.previousdatepicker').attr("placeholder", "mm/dd/yyyy");
                $('input.previousdatepicker').on('apply.daterangepicker', function (ev, picker) {
                    $(this).val(picker.startDate.format('MM/DD/YYYY'));
                    $('input.previousdatepicker').trigger('keyup');
                });

                $('input.previousdatepicker').on('cancel.daterangepicker', function (ev, picker) {
                    $(this).val('');
                });

            });
        }
    };
    // TAGIFY
    topfarms.customerTagify = function () {
        if ($('.customer-tags').exists()) {
            loadScript(plugin_path + 'tagify/tagify.min.js', function () {
                var input = document.querySelector('input[name=customer-tags]');
                new Tagify(input)
            });
        }
    };

    // TOUCHSPIN
    topfarms.subtractTouchSpin = function () {
        if ($('.subtract-quantity').exists()) {
            loadScript(plugin_path + 'bootstrap-touchspin/jquery.bootstrap-touchspin.min.js', function () {
                $("input[name='subtract-quantity']").TouchSpin({
                    min: 0,
                    max: 100,
                    step: 1,
                    boostat: 5,
                    maxboostedstep: 10,
                });
            });
        }
    };

    // PRODUCT SLIDER
    topfarms.productSlider = function () {
        if ($('.slider-for').exists()) {
            loadScript(plugin_path + 'slick/slick.min.js', function () {
                $('.slider-for').slick({
                    slidesToShow: 1,
                    slidesToScroll: 1,
                    arrows: false,
                    fade: true,
                    asNavFor: '.slider-nav'
                });

                $('.slider-nav').slick({
                    slidesToShow: 3,
                    slidesToScroll: 1,
                    asNavFor: '.slider-for',
                    dots: true,
                    centerMode: true,
                    focusOnSelect: true
                });

                // keeps thumbnails active when changing main image, via mouse/touch drag/swipe
                $('.slider-for').on('afterChange', function (event, slick, currentSlide, nextSlide) {
                    //remove all active class
                    $('.slider-nav .slick-slide').removeClass('slick-current');
                    //set active class for current slide
                    $('.slider-nav .slick-slide:not(.slick-cloned)').eq(currentSlide).addClass('slick-current');
                });
            });
        }
    };


    // SWITCH TRIGGER TARGET DIV HIDE & SHOW
    topfarms.switchTriggerControl = function () {
        if ($('[data-switch-trigger]').exists()) {
            $('[data-switch-trigger]').change(function () {
                var hiddenId = $(this).attr("data-trigger");
                if ($(this).is(':checked')) {
                    $("#" + hiddenId).show();
                } else {
                    $("#" + hiddenId).hide();
                }
            });

        }
    };

    // MULTI SELECT CHECKBOX
    topfarms.dataGroupCheckbox = function () {
        if ($('[data-group]').exists()) {
            $('.child').change(function () {
                // create var for parent .checkall and group
                var group = $(this).data('group'),
                    checkall = $('.selectall[data-group="' + group + '"]');

                // do we have some checked? Some unchecked? Store as boolean variables
                var someChecked = $('.child[data-group="' + group + '"]:checkbox:checked').length > 0;
                var someUnchecked = $('.child[data-group="' + group + '"]:checkbox:not(:checked)').length > 0;

                // if we have some checked and unchecked, set .checkall, of the correct group, to indeterminate. 
                // If all are checked, set .checkall to checked
                checkall.prop("indeterminate", someChecked && someUnchecked);
                checkall.prop("checked", someChecked || !someUnchecked);

                // fire change() when this loads to ensure states are updated on page load
            }).change();

            // clicking .checkall will check all children in the same group.
            $('.selectall').click(function () {
                var group = $(this).data('group');
                $('.child[data-group="' + group + '"]').prop('checked', this.checked).change();
            });

        }
    };




    /****************************************************
    Window load and functions
    ****************************************************/
    var _arr = {};

    function loadScript(scriptName, callback) {
        if (!_arr[scriptName]) {
            _arr[scriptName] = true;
            var body = document.getElementsByTagName('body')[0];
            var script = document.createElement('script');
            script.type = 'text/javascript';
            script.src = scriptName;
            script.onload = callback;
            body.appendChild(script);
        } else if (callback) {
            callback();
        }
    };

    //Window load functions
    //  $window.on("load", function () {
    //    topfarms.preloader()
    //  });

    //Document ready functions
    $document.ready(function () {
        topfarms.togglePassword();
        topfarms.selectServices();
        topfarms.addEmployeeSA();
        topfarms.bootstrapToggle();
        topfarms.simpleBar();
        topfarms.svgInject();
        topfarms.switchTriggerControl();
        topfarms.bootstrapSelect();
        topfarms.toggleTooltip();
        topfarms.dateRangePicker();
        topfarms.dataGroupCheckbox();
        topfarms.customerTagify();
        topfarms.subtractTouchSpin();
        topfarms.productSlider();
    });

})(jQuery);







/*--------------*/



$(function () {
    $('[data-toggle="tooltip"]').tooltip();
    $('[data-tooltip="tooltip"]').tooltip();
})

