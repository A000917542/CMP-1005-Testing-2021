window.addEventListener('DOMContentLoaded', () => {

    let form = $('#calculateForm');
    form.on('submit', (evt) => {
        evt.preventDefault();

        let leftNumber = $('#leftNumber').val();
        let rightNumber = $('#rightNumber').val();

        if (leftNumber > 0 && rightNumber > 0) {
            fetch(`https://localhost:44388/Calculate/add?leftNumber=${leftNumber}&rightNumber=${rightNumber}`)
                .then((response) => response.text())
                .then((body) => {
                    let answer = `<p>Answer is <output id="calculation_answer">${body}</output>.</p>`;
                    form.append(answer);
                });
        }
    });

});