(function () {
    const updateUI = () => {
        // --- 1. Header (Profil Şəkli və Başlıq) ---
        const topbarWrapper = document.querySelector('.topbar-wrapper');
        if (topbarWrapper && !document.getElementById('custom-header')) {
            const oldLogo = topbarWrapper.querySelector('a');
            if (oldLogo) oldLogo.style.display = 'none';

            const header = document.createElement('div');
            header.id = 'custom-header';
            header.style.cssText = "display:flex; align-items:center; width:100%; padding: 20px 0;";

            header.innerHTML = `
                <div style="display:flex; align-items:center; gap:30px;">
                    <div style="position:relative;">
                        <img src="https://media.licdn.com/dms/image/v2/D5603AQEgUQyNgZOpRA/profile-displayphoto-scale_200_200/B56Z0AS_fuKYAY-/0/1773826477106?e=1776902400&v=beta&t=H7uB-YV7_9B6SyGzWZS_vNKI_Xr748edgW2fYqXKd6s"
                             style="width:100px; height:100px; border-radius:50%; border:4px solid #58a6ff; object-fit:cover; box-shadow: 0 0 20px rgba(88,166,255,0.5); display:block;">
                        <div style="position:absolute; bottom:5px; right:5px; width:18px; height:18px; background:#3fb950; border:3px solid #0d1117; border-radius:50%;" title="Online"></div>
                    </div>
                    <div>
                        <h1 style="color:#f0f6fc; margin:0; font-size:32px; font-family:sans-serif; letter-spacing:1px; text-transform:uppercase;">
                            EDUCATION <span style="color:#58a6ff;">API</span>
                        </h1>
                        <div style="color:#8b949e; font-size:18px; margin-top:8px; font-weight:500; font-family: 'JetBrains Mono', monospace;">
                            Sanan Ahmadzadadeh <span style="color:#30363d; margin:0 10px;">|</span> <span style="color:#3fb950;"> Backend Developer</span>
                        </div>
                    </div>
                </div>
            `;
            topbarWrapper.prepend(header);
        }

        // --- 2. Düymələrin Hizasını Düzəltmək (Flex Container) ---
        const info = document.querySelector('.info');
        if (info && !document.getElementById('social-btns-row')) {
            const btnRow = document.createElement('div');
            btnRow.id = 'social-btns-row';
            // Düymələri yan-yana düzmək üçün flex istifadə edirik
            btnRow.style.cssText = "display:flex; align-items:center; gap:12px; margin-top:15px; flex-wrap:wrap;";

            // LinkedIn və GitHub linklərini bu cərgəyə daşıyırıq
            const allLinks = info.querySelectorAll('a');
            allLinks.forEach(link => {
                if (link.href.includes('linkedin.com') || link.href.includes('github.com')) {
                    btnRow.appendChild(link);
                }
            });
            info.appendChild(btnRow);

            // Mətndəki <br> teqlərini gizlədirik ki, hiza pozulmasın
            const lineBreaks = info.querySelectorAll('br');
            lineBreaks.forEach(br => br.style.display = 'none');
        }

        // --- 3. Düymələrin Dizaynı ---
        const links = document.querySelectorAll('#social-btns-row a');
        links.forEach(link => {
            // LinkedIn Dizaynı
            if (link.href.includes('linkedin.com') && !link.classList.contains('styled-btn')) {
                link.classList.add('styled-btn');
                link.style.textDecoration = "none";
                link.innerHTML = `
                    <div style="display:inline-flex; align-items:center; gap:10px; background:#0077b5; color:white; padding:10px 22px; border-radius:8px; font-weight:bold; font-size:14px; transition: 0.3s; box-shadow: 0 4px 15px rgba(0,119,181,0.3); border: 1px solid rgba(255,255,255,0.1); cursor:pointer;">
                        <svg xmlns="http://w3.org" viewBox="0 0 24 24" width="20" height="20" fill="white">
                            <path d="M19 0h-14c-2.761 0-5 2.239-5 5v14c0 2.761 2.239 5 5 5h14c2.762 0 5-2.239 5-5v-14c0-2.761-2.238-5-5-5zm-11 19h-3v-11h3v11zm-1.5-12.268c-.966 0-1.75-.79-1.75-1.764s.784-1.764 1.75-1.764 1.75.79 1.75 1.764-.783 1.764-1.75 1.764zm13.5 12.268h-3v-5.604c0-3.368-4-3.113-4 0v5.604h-3v-11h3v1.765c1.396-2.586 7-2.777 7 2.476v6.759z""")/>>
                        </svg>
                        LinkedIn
                    </div>
                `;
            }

            // GitHub Dizaynı
            if (link.href.includes('github.com') && !link.classList.contains('styled-btn-gh')) {
                link.classList.add('styled-btn-gh');
                link.style.textDecoration = "none";
                link.innerHTML = `
                    <div style="display:inline-flex; align-items:center; gap:10px; background:#f0f6fc; color:#0d1117; padding:10px 22px; border-radius:8px; font-weight:bold; font-size:14px; transition: 0.3s; box-shadow: 0 4px 15px rgba(255,255,255,0.1); border: 1px solid #30363d; cursor:pointer;">
                        <svg height="20" width="20" viewBox="0 0 16 16" fill="currentColor">
                            <path d="M8 0C3.58 0 0 3.58 0 8c0 3.54 2.29 6.53 5.47 7.59.4.07.55-.17.55-.38 0-.19-.01-.82-.01-1.49-2.01.37-2.53-.49-2.69-.94-.09-.23-.48-.94-.82-1.13-.28-.15-.68-.52-.01-.53.63-.01 1.08.58 1.23.82.72 1.21 1.87.87 2.33.66.07-.52.28-.87.51-1.07-1.78-.2-3.64-.89-3.64-3.95 0-.87.31-1.59.82-2.15-.08-.2-.36-1.02.08-2.12 0 0 .67-.21 2.2.82.64-.18 1.32-.27 2-.27.68 0 1.36.09 2 .27 1.53-1.04 2.2-.82 2.2-.82.44 1.1.16 1.92.08 2.12.51.56.82 1.27.82 2.15 0 3.07-1.87 3.75-3.65 3.95.29.25.54.73.54 1.48 0 1.07-.01 1.93-.01 2.2 0 .21.15.46.55.38A8.013 8.013 0 0016 8c0-4.42-3.58-8-8-8z"></path>
                        </svg>
                        GitHub
                    </div>
                `;
            }
        });
    };

    new MutationObserver(() => updateUI()).observe(document, { childList: true, subtree: true });
})();
