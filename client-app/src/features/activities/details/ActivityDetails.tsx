import { observer } from "mobx-react-lite";
import React, { useContext, useEffect } from "react";
import { RouteComponentProps } from "react-router-dom";
import { Grid } from "semantic-ui-react";
import { LoadingComponent } from "../../../app/layouts/LoadingComponent";
import ActivityStore from "../../../app/stores/activityStore";
import { ActivityDetailedChats } from "./ActivityDetailedChats";
import ActivityDetailedHeader from "./ActivityDetailedHeader";
import { ActivityDetailedInfo } from "./ActivityDetailedInfo";
import { ActivityDetailedSidebar } from "./ActivityDetailedSidebar";

interface Wesent {
  id: string;
}

const ActivityDetails: React.FC<RouteComponentProps<Wesent>> = ({
  match,
  
}) => {
  const activityStore = useContext(ActivityStore);
  const { activity, loadActivity, loadingInitial } = activityStore;
  useEffect(() => {
    loadActivity(match.params.id);
  }, [loadActivity, match.params.id]);

  if (loadingInitial || !activity)
    return <LoadingComponent content="Loading Activity..." />;

  return (
    <Grid>
      <Grid.Column width={10}>
        <ActivityDetailedHeader activity ={activity} />
        <ActivityDetailedInfo  activity ={activity}/>
        <ActivityDetailedChats />
      </Grid.Column>
      <Grid.Column width={6}>
        <ActivityDetailedSidebar />
      </Grid.Column>
    </Grid>
    // <Card fluid>
    //   <Image
    //     src={`/assets/categoryImages/${activity!.category}.jpg`}
    //     wrapped
    //     ui={false}
    //   />
    //   <Card.Content>
    //     <Card.Header>{activity!.title} </Card.Header>
    //     <Card.Meta>
    //       <span>{activity!.date}</span>
    //     </Card.Meta>
    //     <Card.Description>{activity!.description}</Card.Description>
    //   </Card.Content>
    //   <Card.Content extra>
    //     <Button.Group widths={2}>
    //       <Button
    //         as={Link}
    //         to={`/manage/${activity.id}`}
    //         //onClick={() => openEditForm(activity!.id)}
    //         basic
    //         color="blue"
    //         content="Edit"
    //       />
    //       <Button
    //         onClick={() => history.push("/activities")}
    //         //onClick={cancelSelectedActivity}
    //         basic
    //         color="grey"
    //         content="Cancel"
    //       />
    //     </Button.Group>
    //   </Card.Content>
    // </Card>
  );
};

export default observer(ActivityDetails);
