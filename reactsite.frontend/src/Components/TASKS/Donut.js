import {
    Chart,
    ChartTitle,
    ChartLegend,
    ChartSeries,
    ChartSeriesItem,
    ChartSeriesLabels,
} from "@progress/kendo-react-charts";
import { COLORS } from "./constants";

// https://dzen.ru/media/webformyself/vizualizaciia-dannyh-legkoe-postroenie-grafikov-react-608a46c8ba38c87e471e1059
const applicationsStatusThisMonth = [
    {
        status: "Accepted",
        value: 14,
        color: COLORS.accepted,
    },
    {
        status: "Interviewing",
        value: 14,
        color: COLORS.interviewing,
    },
    {
        status: "Rejected",
        value: 40,
        color: COLORS.rejected,
    },
    {
        status: "Pending",
        value: 32,
        color: COLORS.pending,
    },
];

// Show category label for each item in the donut graph
const labelContent = e => e.category;

const Charts = props => {
    return (
        <Chart>
            <ChartTitle text="Активность за день" />
            <ChartLegend visible={false} />
            <ChartSeries>
                <ChartSeriesItem
                    type="donut"
                    data={applicationsStatusThisMonth}
                    categoryField="status"
                    field="value"
                >
                    <ChartSeriesLabels
                        color="#fff"
                        background="none"
                        content={labelContent}
                    />
                </ChartSeriesItem>
            </ChartSeries>
        </Chart>
    );
};

export default Charts;