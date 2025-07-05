﻿
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

//buble
window.updateChart2 = (labels, dataValues) => {
    setTimeout(() => {
        const canvas = document.getElementById('landChart2');
        if (!canvas) {
            console.error("Canvas element not found!");
            return;
        }

        const ctx = canvas.getContext('2d');
        const backgroundColors = generateRandomColors(dataValues.length);

        const scatterData = dataValues.map((val, i) => ({
            x: i + 1,
            y: val
        }));

        new Chart(ctx, {
            type: 'bubble',
            data: {
                datasets: [{
                    label: 'Kategori Tanah',
                    data: scatterData,
                    backgroundColor: backgroundColors,
                    borderColor: '#fff',
                    borderWidth: 1,
                    pointRadius: 6,
                    pointHoverRadius: 8
                }]
            },
            options: {
                responsive: true,
                maintainAspectRatio: false,
                scales: {
                    x: {
                        title: {
                            display: true,
                            text: 'Index'
                        },
                        beginAtZero: true
                    },
                    y: {
                        title: {
                            display: true,
                            text: 'Jumlah'
                        },
                        beginAtZero: true
                    }
                },
                plugins: {
                    legend: {
                        display: true,
                        position: 'bottom'
                    },
                    tooltip: {
                        callbacks: {
                            label: function (ctx) {
                                const label = labels?.[ctx.dataIndex] || `Data ${ctx.dataIndex + 1}`;
                                return `${label} → Jumlah: ${ctx.raw.y}`;
                            }
                        }
                    }
                }
            }
        });
    }, 500);
};

const generateRandomColors = (count) => {
    const colors = [];
    for (let i = 0; i < count; i++) {
        const color = `hsl(${Math.floor(Math.random() * 360)}, 70%, 60%)`;
        colors.push(color);
    }
    return colors;
};

window.updateChart3 = (labels, dataValues) => {
    setTimeout(() => {
        const canvas = document.getElementById('landChart3');
        if (!canvas) {
            console.error("Canvas element not found!");
            return;
        }

        const ctx = canvas.getContext('2d');
        const randomColors = generateRandomColors(dataValues.length);

        new Chart(ctx, {
            type: 'pie',
            data: {
                labels: labels,
                datasets: [{
                    data: dataValues,
                    backgroundColor: randomColors,
                    borderColor: '#ffffff',
                    borderWidth: 2,
                    hoverOffset: 10
                }]
            },
            options: {
                responsive: true,
                maintainAspectRatio: false,
                plugins: {
                    legend: {
                        display: true,
                        position: 'top'
                    },
                    tooltip: {
                        callbacks: {
                            label: (context) => {
                                const label = context.label || '';
                                const value = context.parsed || 0;
                                return `${label}: ${value.toLocaleString()}`;
                            }
                        }
                    }
                }
            }
        });
    }, 500);
};


window.updateChart4 = (labels, dataValues) => {
    setTimeout(() => {
        const canvas = document.getElementById('landChart4');
        if (!canvas) {
            console.error("Canvas element not found!");
            return;
        }

        const ctx = canvas.getContext('2d');
        const randomColors = generateRandomColors(dataValues.length);

        new Chart(ctx, {
            type: 'bar',
            data: {
                labels: labels,
                datasets: [{
                    data: dataValues,
                    backgroundColor: randomColors,
                    borderColor: '#ffffff',
                    borderWidth: 2,
                    hoverOffset: 10
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
    }, 500);
};

window.updateChart5 = (labels, dataValues) => {
    setTimeout(() => {
        const canvas = document.getElementById('ChartKosong1');
        if (!canvas) {
            console.error("Canvas element not found!");
            return;
        }

        const ctx = canvas.getContext('2d');
        const randomColors = generateRandomColors(dataValues.length);

        new Chart(ctx, {
            type: 'doughnut',
            data: {
                labels: labels,
                datasets: [{
                    data: dataValues,
                    backgroundColor: randomColors,
                    borderColor: '#ffffff',
                    borderWidth: 2,
                    hoverOffset: 10
                }]
            },
            options: {
                responsive: true,
                maintainAspectRatio: false,
                plugins: {
                    legend: {
                        display: true,
                        position: 'top'
                    },
                    tooltip: {
                        callbacks: {
                            label: (context) => {
                                const label = context.label || '';
                                const value = context.parsed || 0;
                                return `${label}: ${value.toLocaleString()}`;
                            }
                        }
                    }
                }
            }
        });
    }, 500);
};

window.ChartDisewa = (labels, dataValues) => {
    setTimeout(() => {
        const canvas = document.getElementById('ChartSewaan');
        if (!canvas) {
            console.error("Canvas element not found!");
            return;
        }

        const ctx = canvas.getContext('2d');

        // Generate random colors based on data length
        const randomColors = dataValues.map(() => getRandomColor());

        new Chart(ctx, {
            type: 'bar',
            data: {
                labels: labels,
                datasets: [{
                    label: 'Tanah Wakaf',
                    data: dataValues,
                    backgroundColor: randomColors,
                    borderColor: randomColors,
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
    }, 500);
};

window.ChartBukanDisewa = (labels, dataValues) => {
    setTimeout(() => {
        const canvas = document.getElementById('ChartBukanSewaan');
        if (!canvas) {
            console.error("Canvas element not found!");
            return;
        }

        const ctx = canvas.getContext('2d');
        const backgroundColors = generateRandomColors(dataValues.length);

        const scatterData = dataValues.map((val, i) => ({
            x: i + 1,
            y: val
        }));

        new Chart(ctx, {
            type: 'bubble',
            data: {
                datasets: [{
                    label: 'Kategori Tanah',
                    data: scatterData,
                    backgroundColor: backgroundColors,
                    borderColor: '#fff',
                    borderWidth: 1,
                    pointRadius: 6,
                    pointHoverRadius: 8
                }]
            },
            options: {
                responsive: true,
                maintainAspectRatio: false,
                scales: {
                    x: {
                        title: {
                            display: true,
                            text: 'Index'
                        },
                        beginAtZero: true
                    },
                    y: {
                        title: {
                            display: true,
                            text: 'Jumlah'
                        },
                        beginAtZero: true
                    }
                },
                plugins: {
                    legend: {
                        display: true,
                        position: 'bottom'
                    },
                    tooltip: {
                        callbacks: {
                            label: function (ctx) {
                                const label = labels?.[ctx.dataIndex] || `Data ${ctx.dataIndex + 1}`;
                                return `${label} → Jumlah: ${ctx.raw.y}`;
                            }
                        }
                    }
                }
            }
        });
    }, 500);
};

window.pecahanwakaf = (labels, dataValues) => {
    setTimeout(() => {
        const canvas = document.getElementById('ChartPecahanWakaf');
        if (!canvas) {
            console.error("Canvas element not found!");
            return;
        }

        const ctx = canvas.getContext('2d');
        const randomColors = generateRandomColors(dataValues.length);

        new Chart(ctx, {
            type: 'doughnut',
            data: {
                labels: labels,
                datasets: [{
                    data: dataValues,
                    backgroundColor: randomColors,
                    borderColor: '#ffffff',
                    borderWidth: 2,
                    hoverOffset: 10
                }]
            },
            options: {
                responsive: true,
                maintainAspectRatio: false,
                plugins: {
                    legend: {
                        display: true,
                        position: 'top'
                    },
                    tooltip: {
                        callbacks: {
                            label: (context) => {
                                const label = context.label || '';
                                const value = context.parsed || 0;
                                return `${label}: ${value.toLocaleString()}`;
                            }
                        }
                    }
                }
            }
        });
    }, 500);
};



function getRandomColor() {
    const letters = '0123456789ABCDEF';
    let color = '#';
    for (let i = 0; i < 6; i++) {
        color += letters[Math.floor(Math.random() * 16)];
    }
    return color;
}