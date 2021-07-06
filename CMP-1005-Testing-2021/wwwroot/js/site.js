window.addEventListener('DOMContentLoaded', () => {

    let form = $('#calculateForm');
    form.on('submit', (evt) => {
        evt.preventDefault();

        let leftNumber = $('#leftNumber').val();
        let rightNumber = $('#rightNumber').val();
        let operation = $('#operation-group input[type="radio"]:checked').val();
        
        if (leftNumber > 0 && rightNumber > 0 && operation != undefined) {
            fetch(`https://localhost:44388/Calculate/${operation}?leftNumber=${leftNumber}&rightNumber=${rightNumber}`)
                .then((response) => response.text())
                .catch((error) => {
                    console.error(error.message);
                    form.off('submit');
                    form.submit();
                })
                .then((body) => {
                    let answer = `<p>Answer is <output id="calculation_answer">${body}</output>.</p>`;
                    form.append(answer);
                });
        }
    });

});