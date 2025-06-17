
window.updateChart = (labels, dataValues) => {
    setTimeout(() => {
        var canvas = document.getElementById('landChart');
        if (!canvas) {
            console.error("Canvas element not found!");
            return;
        }
        var ctx = canvas.getContext('2d');
        new Chart(ctx, {
            type: 'bar',
            data: {
                labels: labels,
                datasets: [{
                    label: 'Tanah Wakaf',
                    data: dataValues,
                    backgroundColor: ['#4361ee', '#3a86ff', '#4cc9f0', '#ffd166', '#ef476f', '#6c757d', '#7209b7'],
                    borderColor: ['#4361ee', '#3a86ff', '#4cc9f0', '#ffd166', '#ef476f', '#6c757d', '#7209b7'],
                    borderWidth: 1
                }]
            },
            options: {
                responsive: true,
                maintainAspectRatio: false,
                scales: {
                    y: { beginAtZero: true },
                    x: { grid: { display: false } }
                },
                plugins: { legend: { display: false } }
            }
        });
    }, 500); // Delay execution slightly
};


window.updateChart2 = (labels, dataValues) => {
    setTimeout(() => {
        var canvas = document.getElementById('landChart2');
        if (!canvas) {
            console.error("Canvas element not found!");
            return;
        }
        var ctx = canvas.getContext('2d');
        new Chart(ctx, {
            type: 'line', // Change from 'bar' to 'line'
            data: {
                labels: labels,
                datasets: [{
                    label: 'Kategori Tanah :',
                    data: dataValues,
                    backgroundColor: 'rgba(67, 97, 238, 0.2)', // Semi-transparent color for visibility
                    borderColor: '#4361ee', // Line color
                    borderWidth: 2,
                    pointBackgroundColor: '#3a86ff', // Color of data points
                    pointBorderColor: '#ffffff',
                    pointRadius: 5, // Size of data points
                    fill: false // Fills area below line
                }]
            },
            options: {
                responsive: true,
                maintainAspectRatio: false,
                scales: {
                    y: { beginAtZero: true },
                    x: { grid: { display: false } }
                },
                plugins: { legend: { display: true } } // Show legend
            }
        });
    }, 500); // Delay execution slightly
};

