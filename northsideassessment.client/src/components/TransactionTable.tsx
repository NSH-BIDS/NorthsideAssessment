import React, { useEffect, useState } from 'react';

interface Transaction {
    transactionId: string;
    department: string;
    amount: number;
    date: string;
    description: string;
}

const TransactionTable = () => {
    const [transactions, setTransactions] = useState<Transaction[]>([]);
    const [department, setDepartment] = useState('');
    const [start, setStart] = useState('');
    const [end, setEnd] = useState('');

    const fetchTransactions = async () => {
        const params = new URLSearchParams();
        if (department) params.append('department', department);
        if (start) params.append('start', start);
        if (end) params.append('end', end);

        const res = await fetch(`https://localhost:7014/Transaction?${params.toString()}`);
        console.log(res);
        const data = await res.json();
        setTransactions(data);
    };

    useEffect(() => {
        fetchTransactions();
    }, []);

    return (
        <div>
            <h2>Transaction Viewer</h2>
            <div style={{ marginBottom: '1em' }}>
                <input
                    placeholder="Department"
                    value={department}
                    onChange={(e) => setDepartment(e.target.value)}
                />
                <input type="date" value={start} onChange={(e) => setStart(e.target.value)} />
                <input type="date" value={end} onChange={(e) => setEnd(e.target.value)} />
                <button onClick={fetchTransactions}>Filter</button>
            </div>

            <table>
                <thead>
                    <tr>
                        <th>Date</th>
                        <th>Department</th>
                        <th>Description</th>
                        <th>Amount ($)</th>
                    </tr>
                </thead>
                <tbody>
                    {transactions.map((tx) => (
                        <tr key={tx.transactionId}>
                            <td>{new Date(tx.date).toLocaleDateString()}</td>
                            <td>{tx.department}</td>
                            <td>{tx.description}</td>
                            <td>{tx.amount.toFixed(2)}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
};

export default TransactionTable;
