document.addEventListener('DOMContentLoaded', function () {
    const navItems = document.querySelectorAll('.nav-item');

    navItems.forEach(item => {
        item.addEventListener('click', function (e) {
            if (!this.classList.contains('logout')) {
                e.preventDefault();

                navItems.forEach(nav => nav.classList.remove('active'));
                this.classList.add('active');
                updatePanelContent(this);
            }
        });
    });

    function updatePanelContent(selectedItem) {
        const contentSections = document.querySelectorAll('.content-section');
        const sectionTitle = selectedItem.querySelector('span').textContent;

        contentSections.forEach(section => {
            section.style.display = 'none';
        });

        console.log('در حال بارگذاری بخش:', sectionTitle);

        setTimeout(() => {
            contentSections.forEach(section => {
                section.style.display = 'block';
            });
        }, 500);
    }

    const avatarEditBtn = document.querySelector('.avatar-edit-btn');
    if (avatarEditBtn) {
        avatarEditBtn.addEventListener('click', function () {
            const input = document.createElement('input');
            input.type = 'file';
            input.accept = 'image/*';

            input.onchange = function (e) {
                const file = e.target.files[0];
                if (file) {
                    const reader = new FileReader();
                    reader.onload = function (e) {
                        const avatarImg = document.querySelector('.avatar-img');
                        avatarImg.src = e.target.result;

                        avatarEditBtn.innerHTML = '<i class="fas fa-spinner fa-spin"></i>';

                        setTimeout(() => {
                            avatarEditBtn.innerHTML = '<i class="fas fa-camera"></i>';
                            alert('عکس پروفایل با موفقیت تغییر کرد!');
                        }, 1500);
                    };
                    reader.readAsDataURL(file);
                }
            };

            input.click();
        });
    }

    const summaryCards = document.querySelectorAll('.summary-card');
    summaryCards.forEach(card => {
        card.addEventListener('mouseenter', function () {
            this.style.transform = 'translateY(-5px)';
        });

        card.addEventListener('mouseleave', function () {
            this.style.transform = 'translateY(0)';
        });
    });

    function showLoading() {
        const content = document.querySelector('.panel-content');
        content.innerHTML = `
            <div class="loading-container">
                <i class="fas fa-spinner fa-spin fa-2x"></i>
                <p>در حال بارگذاری...</p>
            </div>
        `;
    }
});

const loadingStyle = document.createElement('style');
loadingStyle.textContent = `
    .loading-container {
        display: flex;
        flex-direction: column;
        align-items: center;
        justify-content: center;
        padding: 60px 20px;
        color: #666;
    }
    
    .loading-container i {
        margin-bottom: 15px;
        color: #667eea;
    }
`;
document.head.appendChild(loadingStyle);