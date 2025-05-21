window.renderBarChart = (canvasId, labels, data, label) => {
    //const ctx = document.getElementById(canvasId);//.getContext('2d');
    //const teste = ctx.getContext('2d'); // This line is not necessary, ctx already has the context 
    const ctx = document.getElementById(canvasId);
    if (!ctx) {
        console.error(`Canvas with id '${canvasId}' not found.`);
        return;
    }
    const teste = ctx.getContext('2d');
    if (window.myChart) {
        window.myChart.destroy(); // avoid overlapping charts
    }

    window.myChart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: labels,
            datasets: [{
                label: label,
                data: data,
                backgroundColor: 'rgba(54, 162, 235, 0.7)',
                borderColor: 'rgba(54, 162, 235, 1)',
                borderWidth: 1
            }]
        },
        options: {
            responsive: true,
            scales: {
                y: {
                    beginAtZero: true
                }
            }
        }
    });
};