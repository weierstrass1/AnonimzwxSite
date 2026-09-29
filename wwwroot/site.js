// YouTube facade: the iframe is only created when the thumbnail is clicked.
document.addEventListener('click', (e) => {
  const yt = e.target.closest('.yt');
  if (!yt || yt.querySelector('iframe')) return;
  const f = document.createElement('iframe');
  f.src = `https://www.youtube-nocookie.com/embed/${yt.dataset.id}?autoplay=1&rel=0`;
  f.allow = 'autoplay; encrypted-media; picture-in-picture; fullscreen';
  f.allowFullscreen = true;
  f.title = 'Video';
  yt.replaceChildren(f);
});
