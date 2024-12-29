let currentSlideIndex = 0;  // Индекс текущего слайда

// Функция для отображения текущего слайда
function showSlide(index) {
    const slides = document.querySelectorAll('.slide'); // Получаем все слайды
    slides.forEach(slide => {
        slide.classList.remove('active'); // Убираем класс 'active' со всех слайдов
    });
    slides[index].classList.add('active'); // Добавляем класс 'active' только для текущего слайда
}

// Переход к следующему слайду
function nextSlide() {
    const slides = document.querySelectorAll('.slide'); // Получаем все слайды
    currentSlideIndex = (currentSlideIndex + 1) % slides.length; // Переход к следующему слайду
    showSlide(currentSlideIndex); // Показываем новый слайд
}

// Переход к предыдущему слайду
function prevSlide() {
    const slides = document.querySelectorAll('.slide'); // Получаем все слайды
    currentSlideIndex = (currentSlideIndex - 1 + slides.length) % slides.length; // Переход к предыдущему слайду
    showSlide(currentSlideIndex); // Показываем новый слайд
}

// При загрузке страницы отображаем первый слайд
document.addEventListener('DOMContentLoaded', () => {
    showSlide(currentSlideIndex); // Показываем первый слайд при загрузке
});
