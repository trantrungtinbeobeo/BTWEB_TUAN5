(function () {
  window.bookShop = {
    buy: function (title, quantityInputId) {
      var input = document.getElementById(quantityInputId);
      var quantity = input ? Number(input.value) : 1;
      if (!quantity || quantity < 1) {
        alert('Vui lòng nhập số lượng hợp lệ.');
        return;
      }

      alert('Bạn đã chọn mua ' + quantity + ' cuốn "' + title + '". Cảm ơn bạn!');
    }
  };
})();
