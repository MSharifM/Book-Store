// توابع مربوط به صفحات لاگین و ثبت‌نام

// نمایش/مخفی کردن رمز عبور
function togglePassword(inputId) {
    const passwordInput = document.getElementById(inputId);
    const toggleIcon = passwordInput.parentNode.querySelector('.password-toggle i');

    if (passwordInput.type === 'password') {
        passwordInput.type = 'text';
        toggleIcon.classList.remove('fa-eye');
        toggleIcon.classList.add('fa-eye-slash');
    } else {
        passwordInput.type = 'password';
        toggleIcon.classList.remove('fa-eye-slash');
        toggleIcon.classList.add('fa-eye');
    }
}

// اعتبارسنجی ایمیل
function validateEmail(email) {
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailRegex.test(email);
}

// اعتبارسنجی شماره تلفن ایرانی
function validatePhone(phone) {
    const phoneRegex = /^09[0-9]{9}$/;
    return phoneRegex.test(phone);
}

// اعتبارسنجی قدرت رمز عبور
function validatePassword(password) {
    return password.length >= 6;
}

// نمایش خطا
function showError(input, message) {
    const formGroup = input.closest('.form-group');
    const validationMessage = formGroup.querySelector('.validation-message');

    input.classList.add('error');
    input.classList.remove('success');
    validationMessage.textContent = message;
}

// نمایش موفقیت
function showSuccess(input) {
    const formGroup = input.closest('.form-group');
    const validationMessage = formGroup.querySelector('.validation-message');

    input.classList.remove('error');
    input.classList.add('success');
    validationMessage.textContent = '';
}

// اعتبارسنجی بلادرنگ
function setupRealTimeValidation() {
    const inputs = document.querySelectorAll('.form-control');

    inputs.forEach(input => {
        input.addEventListener('blur', function () {
            validateField(this);
        });

        input.addEventListener('input', function () {
            if (this.classList.contains('error')) {
                validateField(this);
            }
        });
    });
}

// اعتبارسنجی فیلد
function validateField(field) {
    const value = field.value.trim();

    switch (field.type) {
        case 'email':
            if (!validateEmail(value)) {
                showError(field, 'لطفاً یک ایمیل معتبر وارد کنید');
            } else {
                showSuccess(field);
            }
            break;

        case 'tel':
            if (!validatePhone(value)) {
                showError(field, 'لطفاً یک شماره تلفن معتبر وارد کنید');
            } else {
                showSuccess(field);
            }
            break;

        case 'password':
            if (!validatePassword(value)) {
                showError(field, 'رمز عبور باید حداقل 6 کاراکتر باشد');
            } else {
                showSuccess(field);
            }
            break;

        default:
            if (value === '') {
                showError(field, 'این فیلد الزامی است');
            } else {
                showSuccess(field);
            }
    }
}

// اعتبارسنجی فرم ثبت‌نام
function validateRegisterForm() {
    const form = document.getElementById('registerForm');
    if (!form) return true;

    const inputs = form.querySelectorAll('.form-control[required]');
    let isValid = true;

    inputs.forEach(input => {
        validateField(input);
        if (input.classList.contains('error')) {
            isValid = false;
        }
    });

    // بررسی تطابق رمز عبور
    const password = document.getElementById('password');
    const confirmPassword = document.getElementById('confirmPassword');

    if (password && confirmPassword && password.value !== confirmPassword.value) {
        showError(confirmPassword, 'رمز عبور و تکرار آن مطابقت ندارند');
        isValid = false;
    }

    // بررسی قوانین
    const agreeTerms = document.getElementById('agreeTerms');
    if (agreeTerms && !agreeTerms.checked) {
        alert('لطفاً با قوانین و مقررات موافقت کنید');
        isValid = false;
    }

    return isValid;
}

// اعتبارسنجی فرم ورود
function validateLoginForm() {
    const form = document.getElementById('loginForm');
    if (!form) return true;

    const inputs = form.querySelectorAll('.form-control[required]');
    let isValid = true;

    inputs.forEach(input => {
        validateField(input);
        if (input.classList.contains('error')) {
            isValid = false;
        }
    });

    return isValid;
}

// مدیریت ارسال فرم‌ها
document.addEventListener('DOMContentLoaded', function () {
    setupRealTimeValidation();

    // فرم ثبت‌نام
    const registerForm = document.getElementById('registerForm');
    if (registerForm) {
        registerForm.addEventListener('submit', function (e) {

            if (validateRegisterForm()) {
                // شبیه‌سازی ارسال فرم
                const submitBtn = this.querySelector('.auth-btn');
                const originalText = submitBtn.innerHTML;

                submitBtn.innerHTML = '<i class="fas fa-spinner fa-spin"></i> در حال ایجاد حساب...';
                submitBtn.disabled = true;

                setTimeout(() => {
                    alert('حساب کاربری با موفقیت ایجاد شد!');
                    submitBtn.innerHTML = originalText;
                    submitBtn.disabled = false;
                    // window.location.href = '/Account/Login'; // ریدایرکت به صفحه ورود
                }, 2000);
            }
        });
    }

    // فرم ورود
    const loginForm = document.getElementById('loginForm');
    if (loginForm) {
        loginForm.addEventListener('submit', function (e) {

            if (validateLoginForm()) {
                // شبیه‌سازی ارسال فرم
                const submitBtn = this.querySelector('.auth-btn');
                const originalText = submitBtn.innerHTML;

                submitBtn.innerHTML = '<i class="fas fa-spinner fa-spin"></i> در حال ورود...';
                submitBtn.disabled = true;

                setTimeout(() => {
                    alert('ورود با موفقیت انجام شد!');
                    submitBtn.innerHTML = originalText;
                    submitBtn.disabled = false;
                    // window.location.href = '/'; // ریدایرکت به صفحه اصلی
                }, 2000);
            }
        });
    }
});