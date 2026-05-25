(function () {
  function createCard({ title, author, topic, price, quantity, image }) {
    const grid = document.getElementById('bookGrid');
    if (!grid) return;

    const card = document.createElement('article');
    card.className = 'book-card';

    const imageHtml = image
      ? `<img src="${image}" alt="${title}" />`
      : '<span class="placeholder-cover">BOOK</span>';

    card.innerHTML = `
      <a class="book-card-link" href="#" onclick="alert('Sách demo thêm từ console. Bạn có thể lưu vào DB ở bước tiếp theo!')">
        <div class="book-cover-square">${imageHtml}</div>
        <div class="book-content">
          <h3>${title}</h3>
          <p class="author">${author || 'Chưa rõ tác giả'}</p>
          <p class="meta">${topic || 'Chưa phân loại'}</p>
          <div class="book-bottom">
            <strong>${price || '0'} đ</strong>
            <span>Còn ${quantity ?? 0}</span>
          </div>
        </div>
      </a>`;

    grid.prepend(card);
  }

  window.bookConsole = {
    addBookCard: function (book) {
      createCard(book || {});
      console.info('Đã thêm card sách tạm thời lên giao diện.');
    },
    help: function () {
      console.log('Dùng: bookConsole.addBookCard({ title, author, topic, price, quantity, image })');
    }
  };
})();
